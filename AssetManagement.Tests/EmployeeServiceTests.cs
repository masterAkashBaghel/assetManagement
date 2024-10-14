using NUnit.Framework;
using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Services;
using System.Collections.Generic;
using System;

namespace AssetManagement.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService;

        // Setup method to initialize the test environment
        [SetUp]
        public void Setup()
        {
            // Initialize EmployeeService with a mock or actual EmployeeRepository
            var employeeRepository = new EmployeeRepository();
            _employeeService = new EmployeeService(employeeRepository);
        }

        // Test to verify that AddEmployee successfully adds a new employee
        [Test]
        public void AddEmployee_ShouldAddEmployee()
        {
            // Arrange: Create a new employee
            var employee = new Employee
            {
                EmployeeId = 1,
                Name = "Simba Singh",
                Department = "HR",
                Email = "simba.singh@example.com",
                Password = "password123"
            };

            // Act: Add the employee
            var result = _employeeService.AddEmployee(employee);

            // Assert: Verify that the employee was successfully added
            Assert.IsTrue(result);
        }

        // Test to verify that AddEmployee does not add a duplicate employee
        [Test]
        public void AddEmployee_ShouldNotAddDuplicateEmployee()
        {
            // Arrange: Create a new employee
            var employee = new Employee
            {
                EmployeeId = 1,
                Name = "Simba Singh",
                Department = "HR",
                Email = "simba.singh@example.com",
                Password = "password123"
            };

            // Act: Add the employee for the first time
            _employeeService.AddEmployee(employee);
            // Try to add the same employee again
            var result = _employeeService.AddEmployee(employee);

            // Assert: Verify that the duplicate employee was not added
            Assert.IsFalse(result);
        }

        // Test to verify that GetEmployeeById returns the correct employee
        [Test]
        public void GetEmployeeById_ShouldReturnEmployee()
        {
            // Arrange: Create and add a new employee
            var employee = new Employee
            {
                EmployeeId = 1,
                Name = "Varsha Patil",
                Department = "Trainer",
                Email = "varsha.patil@example.com",
                Password = "password123"
            };
            _employeeService.AddEmployee(employee);

            // Act: Retrieve the employee by ID
            var result = _employeeService.GetEmployeeById(1);

            // Assert: Verify that the retrieved employee matches the added employee
            Assert.IsNotNull(result);
            Assert.AreEqual(employee.EmployeeId, result.EmployeeId);
            Assert.AreEqual(employee.Name, result.Name);
            Assert.AreEqual(employee.Department, result.Department);
            Assert.AreEqual(employee.Email, result.Email);
        }

        // Test to verify that AddEmployee throws an exception for a null employee
        [Test]
        public void AddEmployee_ShouldThrowExceptionForNullEmployee()
        {
            // Assert: Verify that adding a null employee throws an ArgumentNullException
            Assert.Throws<ArgumentNullException>(() => _employeeService.AddEmployee(null));
        }

        // Test to verify that AddEmployee throws an exception for an invalid email
        [Test]
        public void AddEmployee_ShouldThrowExceptionForInvalidEmail()
        {
            // Arrange: Create a new employee with an invalid email
            var employee = new Employee
            {
                EmployeeId = 1,
                Name = "Simba Singh",
                Department = "HR",
                Email = "invalid-email",
                Password = "password123"
            };

            // Assert: Verify that adding an employee with an invalid email throws an ArgumentException
            Assert.Throws<ArgumentException>(() => _employeeService.AddEmployee(employee));
        }
    }
}