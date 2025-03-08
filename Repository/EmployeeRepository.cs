using employee_app.Entities;
using Microsoft.EntityFrameworkCore;

namespace employee_app.Repository
{

    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(int departmentId);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int employeeId);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int departmentId)
        {
            return await _dbContext.employees
                .Where(e => e.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _dbContext.employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _dbContext.employees.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _dbContext.employees.FindAsync(employeeId);
            if (employee is not null)
            {
                _dbContext.employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
