using NUnit.Framework;
using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Services;
using System.Collections.Generic;

namespace AssetManagement.Tests
{
    [TestFixture]
    public class EmployeeServiceTestsTest
    {
        private EmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            // Initialize EmployeeService with mock data or dependencies
            var employeeRepository = new EmployeeRepository();
            _employeeService = new EmployeeService(employeeRepository);
        }

        [Test]
        public void AddEmployee_ShouldAddEmployee()
        {
            var employee = new Employee
            {
                EmployeeId = 1,
                Name = "Simba Singh",
                Department = "HR",
                Email = "simba.singh@example.com",
                Password = "password123"
            };

            var result = _employeeService.AddEmployee(employee);

            Assert.IsTrue(result);
        }

        [Test]
        public void AddEmployee_ShouldNotAddDuplicateEmployee()
        {
            var employee = new Employee
            {
                EmployeeId = 1,
                Name = "Simba Singh",
                Department = "HR",
                Email = "simba.singh@example.com",
                Password = "password123"
            };

            _employeeService.AddEmployee(employee);
            var result = _employeeService.AddEmployee(employee);

            Assert.IsFalse(result);
        }

        [Test]
        public void GetEmployeeById_ShouldReturnEmployee()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 1,
                Name = "Varsha Patil",
                Department = "Trainer",
                Email = "varsha.patil@example.com",
                Password = "password123"
            };
            _employeeService.AddEmployee(employee);

            // Act
            var result = _employeeService.GetEmployeeById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employee.EmployeeId, result.EmployeeId);
            Assert.AreEqual(employee.Name, result.Name);
            Assert.AreEqual(employee.Department, result.Department);
            Assert.AreEqual(employee.Email, result.Email);
        }

        [Test]
        public void AddEmployee_ShouldThrowExceptionForNullEmployee()
        {
            Assert.Throws<ArgumentNullException>(() => _employeeService.AddEmployee(null));
        }

        [Test]
        public void AddEmployee_ShouldThrowExceptionForInvalidEmail()
        {
            var employee = new Employee
            {
                EmployeeId = 1,
                Name = "Simba Singh",
                Department = "HR",
                Email = "invalid-email",
                Password = "password123"
            };

            Assert.Throws<ArgumentException>(() => _employeeService.AddEmployee(employee));
        }
    }
}