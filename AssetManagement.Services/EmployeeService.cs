using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;

namespace AssetManagement.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool AddEmployee(Employee employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }

        public bool UpdateEmployee(Employee employee)
        {
            if (_employeeRepository.GetEmployeeById(employee.EmployeeId) == null)
            {
                throw new EmployeeNotFoundException(employee.EmployeeId);
            }
            return _employeeRepository.UpdateEmployee(employee);
        }

        public bool DeleteEmployee(int employeeId)
        {
            if (_employeeRepository.GetEmployeeById(employeeId) == null)
            {
                throw new EmployeeNotFoundException(employeeId);
            }
            return _employeeRepository.DeleteEmployee(employeeId);
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            if (employee == null)
            {
                throw new EmployeeNotFoundException(employeeId);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }
    }
}