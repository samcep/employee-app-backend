using System.ComponentModel.DataAnnotations;

namespace employee_app.Dtos
{
    public class DepartmentCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
