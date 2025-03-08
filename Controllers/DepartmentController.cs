using AutoMapper;
using employee_app.Dtos;
using employee_app.Entities;
using employee_app.Repository;
using Microsoft.AspNetCore.Mvc;

namespace employee_app.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : GenericControllerBase<Department , DepartmentCreateDto , DepartmentListDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Department> _genericDepartmentRepository;
        public DepartmentController(IGenericRepository<Department> genericRepository , IMapper mapper) : base(genericRepository, mapper)
        {
            _genericDepartmentRepository = genericRepository;
            _mapper = mapper;
        }
        [HttpGet("{departmentId}/employeees")]
        public async Task<ActionResult<IEnumerable<EmployeeListDto>>> GetEmployeesByDepartment(int departmentId)
        {
            try
            {
                var department = await _genericDepartmentRepository.GetByIdAsync(departmentId, "Employees");

                if (department == null)
                {
                    return NotFound($"Department with id {departmentId} not found.");
                }

                if (department.Employees == null || !department.Employees.Any())
                {
                    return NotFound($"No employees found in department with id {departmentId}.");
                }
                var employeeDtos = _mapper.Map<IEnumerable<EmployeeListDto>>(department.Employees);
                return Ok(employeeDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
