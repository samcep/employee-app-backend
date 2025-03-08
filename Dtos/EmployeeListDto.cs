﻿using employee_app.Entities;

namespace employee_app.Dtos
{
    public class EmployeeListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
        public int DepartmentId { get; set; }
    }
}
