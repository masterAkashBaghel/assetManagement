using System;
using AssetManagement.Services;
using AssetManagement.Entities;
using AssetManagement.Business;

namespace AssetManagement.UI
{
    public static class EmployeeMenu
    {
        // Method to display the employee management menu
        public static void Show()
        {
            // Initialize the EmployeeService with an instance of EmployeeRepository
            var employeeService = new EmployeeService(new EmployeeRepository());

            // Infinite loop to keep the menu running until the user chooses to exit
            while (true)
            {
                // Display the menu options
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("-----WELCOME TO EMPLOYEE MANAGEMENT DASHBOARD------");
                Console.WriteLine();
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("4. View Employee by ID");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("5. View All Employees");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("6. Back to Main Menu");
                Console.WriteLine("----------------------------------------------------");

                // Prompt the user to select an option
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                // Handle the user's selection
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
                        return; // Exit the menu
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Method to add a new employee
        static void AddEmployee(EmployeeService employeeService)
        {
            var employee = new Employee();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("-------ADD EMPLOYEE DETAILS--------");
            Console.WriteLine();

            // Prompt the user to enter employee details
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
            Console.WriteLine();

            // Attempt to add the employee using the EmployeeService
            if (employeeService.AddEmployee(employee))
            {
                Console.WriteLine($"Employee {employee.Name} added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add employee.");
            }
        }

        // Method to update an existing employee
        static void UpdateEmployee(EmployeeService employeeService)
        {
            var employee = new Employee();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("-------UPDATE EMPLOYEE DETAILS--------");
            Console.WriteLine();

            // Prompt the user to enter updated employee details
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
            Console.WriteLine();

            // Attempt to update the employee using the EmployeeService
            if (employeeService.UpdateEmployee(employee))
            {
                Console.WriteLine($"Employee {employee.Name} updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update employee.");
            }
        }

        // Method to delete an existing employee
        static void DeleteEmployee(EmployeeService employeeService)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("-------DELETE EMPLOYEE--------");
            Console.WriteLine();

            // Prompt the user to enter the employee ID to delete
            Console.Write("Enter Employee ID: ");
            var employeeId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Attempt to delete the employee using the EmployeeService
            if (employeeService.DeleteEmployee(employeeId))
            {
                Console.WriteLine($"Employee with ID {employeeId} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete employee.");
            }
        }

        // Method to view an employee by their ID
        static void ViewEmployeeById(EmployeeService employeeService)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("-------VIEW EMPLOYEE BY ID--------");
            Console.WriteLine();

            // Prompt the user to enter the employee ID to view
            Console.Write("Enter Employee ID: ");
            var employeeId = int.Parse(Console.ReadLine());

            // Retrieve the employee using the EmployeeService
            var employee = employeeService.GetEmployeeById(employeeId);
            Console.WriteLine();

            // Display the employee details if found
            if (employee != null)
            {
                // Print the header
                Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-30}", "ID", "Name", "Department", "Email");
                Console.WriteLine(new string('-', 80)); // Separator line

                // Print the employee details
                Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-30}", employee.EmployeeId, employee.Name, employee.Department, employee.Email);
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // Method to view all employees
        static void ViewAllEmployees(EmployeeService employeeService)
        {
            // Retrieve all employees using the EmployeeService
            var employees = employeeService.GetAllEmployees();

            // Display the employee details if any are found
            if (employees.Any())
            {
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("| {0,-10} | {1,-20} | {2,-20} | {3,-30} |", "ID", "Name", "Department", "Email");
                Console.WriteLine("--------------------------------------------------------------------------------------");

                // Print each employee's details
                foreach (var employee in employees)
                {
                    Console.WriteLine("| {0,-10} | {1,-20} | {2,-20} | {3,-30} |", employee.EmployeeId, employee.Name, employee.Department, employee.Email);
                }

                Console.WriteLine("--------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }
    }
}