using System;

namespace AssetManagement.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public int EmployeeId { get; }

        public EmployeeNotFoundException() : base("Employee not found.")
        {
        }

        public EmployeeNotFoundException(int employeeId)
            : base($"Employee with ID {employeeId} not found.")
        {
            EmployeeId = employeeId;
        }

        public EmployeeNotFoundException(string message) : base(message)
        {
        }

        public EmployeeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public EmployeeNotFoundException(int employeeId, string message)
            : base(message)
        {
            EmployeeId = employeeId;
        }

        public EmployeeNotFoundException(int employeeId, string message, Exception innerException)
            : base(message, innerException)
        {
            EmployeeId = employeeId;
        }

        public override string ToString()
        {
            return $"EmployeeNotFoundException: {Message}, EmployeeId: {EmployeeId}";
        }
    }
}