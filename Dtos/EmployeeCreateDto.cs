using employee_app.Entities;
using System.ComponentModel.DataAnnotations;

namespace employee_app.Dtos
{
    public class EmployeeCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public JobPosition Position { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; }
    }
}
