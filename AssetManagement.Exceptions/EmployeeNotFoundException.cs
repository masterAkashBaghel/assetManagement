using System;

namespace AssetManagement.Exceptions
{

    // Exception class for when an employee is not found
    public class EmployeeNotFoundException : Exception
    {

        // The ID of the employee that was not found
        public int EmployeeId { get; }

        // Default constructor
        public EmployeeNotFoundException() : base("Employee not found.")
        {
        }
        // Constructor with employee ID parameter
        public EmployeeNotFoundException(int employeeId)
            : base($"Employee with ID {employeeId} not found.")
        {
            EmployeeId = employeeId;
        }

        // Constructor with message parameter

        public EmployeeNotFoundException(string message) : base(message)
        {
        }


        // Constructor with message and inner exception parameters
        public EmployeeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // Constructor with employee ID, message, and inner exception parameters
        public EmployeeNotFoundException(int employeeId, string message)
            : base(message)
        {
            EmployeeId = employeeId;
        }

        // Constructor with employee ID, message, and inner exception parameters
        public EmployeeNotFoundException(int employeeId, string message, Exception innerException)
            : base(message, innerException)
        {
            EmployeeId = employeeId;
        }

        // Override the ToString method to include the employee ID , this works by overriding the ToString method to include the employee ID
        public override string ToString()
        {
            return $"EmployeeNotFoundException: {Message}, EmployeeId: {EmployeeId}";
        }
    }
}