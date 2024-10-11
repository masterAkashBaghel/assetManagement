namespace AssetManagement.Entities
{
    public class Employee
    {
        private int employeeId;
        private string? name;
        private string? department;
        private string? email;
        private string? password;

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string? Name
        {
            get { return name; }
            set { name = value; }
        }

        public string? Department
        {
            get { return department; }
            set { department = value; }
        }

        public string? Email
        {
            get { return email; }
            set { email = value; }
        }

        public string? Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}