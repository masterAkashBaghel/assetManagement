namespace AssetManagement.Entities
{
    public class Employee
    {
        // Properties for the Employee entity class ( corresponding to the Employee table in the database)
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}