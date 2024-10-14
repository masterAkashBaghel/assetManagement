using AssetManagement.Entities;
using AssetManagement.Util;
using AssetManagement.Exceptions;
using System.Data.SqlClient;

namespace AssetManagement.Business
{
    // Class to interact with the Employees table in the database implementing the IEmployeeRepository interface
    public class EmployeeRepository : IEmployeeRepository
    {
        // Method to add an employee to the database using the Employee entity class
        public bool AddEmployee(Employee employee)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to insert the employee into the database
                var command = new SqlCommand("INSERT INTO Employees (employee_id, name, department, email, password) VALUES (@EmployeeId, @name, @department, @Email, @Password)", connection);
                // Add the parameters to the command
                command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                command.Parameters.AddWithValue("@name", employee.Name);
                command.Parameters.AddWithValue("@department", employee.Department);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Password", employee.Password);
                // Execute the command and return true if successful
                var result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                // Log the error and return false
                Console.WriteLine(ex.Message);
                return false;


            }
        }

        // Method to update an employee in the database using the Employee entity class
        public bool UpdateEmployee(Employee employee)
        {

            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to update the employee in the database
                var command = new SqlCommand("UPDATE Employees SET name = @name, department = @department, email = @Email, password = @Password WHERE employee_id = @employeeId", connection);
                // Add the parameters to the command
                command.Parameters.AddWithValue("@name", employee.Name);
                command.Parameters.AddWithValue("@department", employee.Department);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Password", employee.Password);
                command.Parameters.AddWithValue("@employeeId", employee.EmployeeId);
                // Execute the command and return true if successful
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // Log the error and throw an AssetNotFoundException
                AssetNotFoundException assetNotFoundException = new("Asset not found", ex);
                throw assetNotFoundException;
            }

        }
        // Method to delete an employee from the database using the employee ID 
        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to delete the employee from the database
                var command = new SqlCommand("DELETE FROM Employees WHERE employee_id = @employeeId", connection);
                // Add the parameter to the command
                command.Parameters.AddWithValue("@employeeId", employeeId);
                // Execute the command and return true if successful

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // Log  using the AssetNotFoundException class and return false
                AssetNotFoundException assetNotFoundException = new("Asset not found", ex);
                throw assetNotFoundException;

            }
        }

        // Method to retrieve an employee by their ID
        public Employee? GetEmployeeById(int employeeId)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to select the employee
                var command = new SqlCommand("SELECT * FROM Employees WHERE employee_id = @employeeId", connection);
                // Add the parameter to the command
                command.Parameters.AddWithValue("@employeeId", employeeId);
                // Execute the command and return the employee if found

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Employee
                    {
                        EmployeeId = (int)reader["employee_id"],
                        Name = (string)reader["name"],
                        Department = (string)reader["department"],
                        Email = (string)reader["email"],
                        Password = (string)reader["password"]
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                //log using the AssetNotFoundException class and return null
                AssetNotFoundException assetNotFoundException = new("Asset not found", ex);
                throw assetNotFoundException;
            }
        }
        // Method to retrieve all employees from the database
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                // using list to store the employees
                var employees = new List<Employee>();
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to select all employees
                var command = new SqlCommand("SELECT * FROM Employees", connection);
                // Execute the command and add each employee to the list

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeId = (int)reader["employee_id"],
                        Name = (string)reader["name"],
                        Department = (string)reader["department"],
                        Email = (string)reader["email"],
                        Password = (string)reader["password"]
                    });
                }
                return employees;
            }
            catch (Exception ex)
            {
                // Log the error and return an empty list
                Console.WriteLine(ex.Message);
                return new List<Employee>();

            }
        }
    }
}