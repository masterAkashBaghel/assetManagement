using AssetManagement.Entities;
using System.Collections.Generic;

namespace AssetManagement.Business
{
    // Interface for the EmployeeRepository class
    public interface IEmployeeRepository
    {

        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int employeeId);
        Employee GetEmployeeById(int employeeId);
        IEnumerable<Employee> GetAllEmployees();
    }
}
