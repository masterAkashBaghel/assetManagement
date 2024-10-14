using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;

namespace AssetManagement.Services
{
    // Service class for the EmployeeRepository class, it works as a bridge between the EmployeeRepository and the service controller
    // Contains methods for adding, updating, deleting, and retrieving employees, and uses the EmployeeRepository class to perform these operations
    public class EmployeeService
    {
        // Instance of the EmployeeRepository class to be used in the service
        private readonly EmployeeRepository _employeeRepository;

        // Constructor for the EmployeeService class that takes an EmployeeRepository object as a parameter
        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Method to add an employee to the repository

        public bool AddEmployee(Employee employee)
        {
            // Call the AddEmployee method of the EmployeeRepository class and return the result
            return _employeeRepository.AddEmployee(employee);
        }

        // Method to update an employee in the repository
        public bool UpdateEmployee(Employee employee)
        {
            // Check if the employee exists in the repository
            if (_employeeRepository.GetEmployeeById(employee.EmployeeId) == null)
            {
                // Throw an EmployeeNotFoundException if the employee does not exist
                throw new EmployeeNotFoundException(employee.EmployeeId);
            }
            // Call the UpdateEmployee method of the EmployeeRepository class and return the result
            return _employeeRepository.UpdateEmployee(employee);
        }

        // Method to delete an employee from the repository
        public bool DeleteEmployee(int employeeId)
        {
            // Check if the employee exists in the repository by calling the GetEmployeeById method of the EmployeeRepository class
            if (_employeeRepository.GetEmployeeById(employeeId) == null)
            {
                // Throw an EmployeeNotFoundException if the employee does not exist
                throw new EmployeeNotFoundException(employeeId);
            }
            // Call the DeleteEmployee method of the EmployeeRepository class and return the result
            return _employeeRepository.DeleteEmployee(employeeId);
        }

        // Method to get an employee by their ID from the repository
        public Employee GetEmployeeById(int employeeId)
        {
            // Check if the employee exists in the repository by calling the GetEmployeeById method of the EmployeeRepository class
            var employee = _employeeRepository.GetEmployeeById(employeeId) ?? throw new EmployeeNotFoundException(employeeId);
            return employee;
        }

        // Method to get all employees from the repository and return them as an IEnumerable
        public IEnumerable<Employee> GetAllEmployees()
        {
            // Call the GetAllEmployees method of the EmployeeRepository class and return the result
            return _employeeRepository.GetAllEmployees();
        }
    }
}