using System;
using AssetManagement.Services;
using AssetManagement.Entities;
using AssetManagement.Business;

namespace AssetManagement.UI
{
    public static class EmployeeMenu
    {
        public static void Show()
        {
            var employeeService = new EmployeeService(new EmployeeRepository());

            while (true)
            {
                Console.WriteLine("Employee Management");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. View Employee by ID");
                Console.WriteLine("5. View All Employees");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddEmployee(employeeService);
                        break;
                    case "2":
                        UpdateEmployee(employeeService);
                        break;
                    case "3":
                        DeleteEmployee(employeeService);
                        break;
                    case "4":
                        ViewEmployeeById(employeeService);
                        break;
                    case "5":
                        ViewAllEmployees(employeeService);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddEmployee(EmployeeService employeeService)
        {
            var employee = new Employee();
            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine();
            Console.Write("Enter Department: ");
            employee.Department = Console.ReadLine();
            Console.Write("Enter Email: ");
            employee.Email = Console.ReadLine();
            Console.Write("Enter Password: ");
            employee.Password = Console.ReadLine();

            if (employeeService.AddEmployee(employee))
            {
                Console.WriteLine("Employee added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add employee.");
            }
        }

        static void UpdateEmployee(EmployeeService employeeService)
        {
            var employee = new Employee();
            Console.Write("Enter Employee ID: ");
            employee.EmployeeId = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine();
            Console.Write("Enter Department: ");
            employee.Department = Console.ReadLine();
            Console.Write("Enter Email: ");
            employee.Email = Console.ReadLine();
            Console.Write("Enter Password: ");
            employee.Password = Console.ReadLine();

            if (employeeService.UpdateEmployee(employee))
            {
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update employee.");
            }
        }

        static void DeleteEmployee(EmployeeService employeeService)
        {
            Console.Write("Enter Employee ID: ");
            var employeeId = int.Parse(Console.ReadLine());

            if (employeeService.DeleteEmployee(employeeId))
            {
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete employee.");
            }
        }

        static void ViewEmployeeById(EmployeeService employeeService)
        {
            Console.Write("Enter Employee ID: ");
            var employeeId = int.Parse(Console.ReadLine());

            var employee = employeeService.GetEmployeeById(employeeId);
            if (employee != null)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.Name}, Department: {employee.Department}, Email: {employee.Email}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void ViewAllEmployees(EmployeeService employeeService)
        {
            var employees = employeeService.GetAllEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.Name}, Department: {employee.Department}, Email: {employee.Email}");
            }
        }
    }
}