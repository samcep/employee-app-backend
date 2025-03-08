﻿namespace employee_app.Entities
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
