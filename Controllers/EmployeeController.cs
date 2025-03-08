using AutoMapper;
using employee_app.Dtos;
using employee_app.Entities;
using employee_app.Repository;
using Microsoft.AspNetCore.Mvc;

namespace employee_app.Controllers
{

    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : GenericControllerBase<Employee , EmployeeCreateDto , EmployeeListDto>
    {
        private readonly IGenericRepository<Employee> _genericRepositoryEmployee;
        private readonly IGenericRepository<Department> _genericRepositoryDepartment;
        private readonly IMapper _mapper;
        public EmployeeController(
            IGenericRepository<Employee> genericRepositoryEmployee,
            IMapper mapper,
            IGenericRepository<Department> genericRepositoryDepartment
            ) : base(genericRepositoryEmployee, mapper)
        {
            _genericRepositoryEmployee = genericRepositoryEmployee;
            _genericRepositoryDepartment = genericRepositoryDepartment;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateEmployee([FromBody] EmployeeCreateDto employeeCreateDto)
        {
            try
            {
                var existsDepartment = await _genericRepositoryDepartment.GetByIdAsync(employeeCreateDto.DepartmentId);
                if(existsDepartment is null)
                {
                    return NotFound("Department id dosen't exists");
                }

                if (!Enum.IsDefined(typeof(JobPosition), employeeCreateDto.Position))
                {
                    return BadRequest("Invalid job position.");
                }
                employeeCreateDto.Salary = CalculateSalary(employeeCreateDto.Position, employeeCreateDto.Salary);
                var employee = _mapper.Map<Employee>(employeeCreateDto);
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _genericRepositoryEmployee.AddAsync(employee);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest("Error creating employee");
            }
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            try
            {
                var existingEmployee = await _genericRepositoryEmployee.GetByIdAsync(id);
                if (existingEmployee == null)
                {
                    return NotFound("Employee not found.");
                }
                var existsDepartment = await _genericRepositoryDepartment.GetByIdAsync(employeeUpdateDto.DepartmentId);
                if (existsDepartment is null)
                {
                    return NotFound("Department ID doesn't exist.");
                }
                if (!Enum.IsDefined(typeof(JobPosition), employeeUpdateDto.Position))
                {
                    return BadRequest("Invalid job position.");
                }

                _mapper.Map(employeeUpdateDto, existingEmployee);

                await _genericRepositoryEmployee.UpdateAsync(id, existingEmployee);

                return NoContent(); 
            }
            catch (Exception)
            {
                return BadRequest("Error updating employee");
            }
        }


        private decimal CalculateSalary(JobPosition position, decimal baseSalary)
        {
            return position switch
            {
                JobPosition.Developer => baseSalary + (baseSalary * 0.10m),
                JobPosition.Manager => baseSalary + (baseSalary * 0.20m),
                JobPosition.HR => baseSalary, 
                JobPosition.Sales => baseSalary, 
                _ => baseSalary
            };
        }
    }

}
