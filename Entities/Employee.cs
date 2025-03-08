namespace employee_app.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
    public enum JobPosition
    {
        Developer,
        Manager,
        HR,
        Sales
    }
}
