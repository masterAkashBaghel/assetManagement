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
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("-------ADD EMPLOYEE DETAILS--------");
            Console.WriteLine();
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

            if (employeeService.AddEmployee(employee))
            {
                Console.WriteLine($"Employee {employee.Name} added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add employee");
            }
        }

        static void UpdateEmployee(EmployeeService employeeService)
        {
            var employee = new Employee();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("-------UPDATE EMPLOYEE DETAILS--------");
            Console.WriteLine();
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

            if (employeeService.UpdateEmployee(employee))
            {
                Console.WriteLine($"Employee {employee.Name} updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update employee.");
            }
        }

        static void DeleteEmployee(EmployeeService employeeService)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("-------DELETE EMPLOYEE--------");
            Console.WriteLine();
            Console.Write("Enter Employee ID: ");
            var employeeId = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (employeeService.DeleteEmployee(employeeId))
            {
                Console.WriteLine("$Employee with ID {employeeId} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete employee.");
            }
        }
        static void ViewEmployeeById(EmployeeService employeeService)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("-------VIEW EMPLOYEE BY ID--------");
            Console.WriteLine();

            Console.Write("Enter Employee ID: ");
            var employeeId = int.Parse(Console.ReadLine());

            var employee = employeeService.GetEmployeeById(employeeId);
            Console.WriteLine();
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

        static void ViewAllEmployees(EmployeeService employeeService)
        {
            var employees = employeeService.GetAllEmployees();
            if (employees.Any())
            {
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("| {0,-10} | {1,-20} | {2,-20} | {3,-30} |", "ID", "Name", "Department", "Email");
                Console.WriteLine("--------------------------------------------------------------------------------------");

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