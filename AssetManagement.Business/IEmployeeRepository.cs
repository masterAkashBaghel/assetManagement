using AssetManagement.Entities;
using System.Collections.Generic;

namespace AssetManagement.Business
{
    public interface IEmployeeRepository
    {
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int employeeId);
        Employee GetEmployeeById(int employeeId);
        IEnumerable<Employee> GetAllEmployees();
    }
}
