using AssetManagement.Entities;
using AssetManagement.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AssetManagement.Business
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool AddEmployee(Employee employee)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("INSERT INTO Employees (employee_id, name, department, email, password) VALUES (@EmployeeId, @name, @department, @Email, @Password)", connection);
                command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                command.Parameters.AddWithValue("@name", employee.Name);
                command.Parameters.AddWithValue("@department", employee.Department);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Password", employee.Password);

                var result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            SqlConnection? connection = null;
            try
            {
                connection = DBConnection.GetConnection();
                var command = new SqlCommand("UPDATE Employees SET name = @name, department = @department, email = @Email, password = @Password WHERE employee_id = @employeeId", connection);
                command.Parameters.AddWithValue("@name", employee.Name);
                command.Parameters.AddWithValue("@department", employee.Department);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Password", employee.Password);
                command.Parameters.AddWithValue("@employeeId", employee.EmployeeId);

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("DELETE FROM Employees WHERE employee_id = @employeeId", connection);
                command.Parameters.AddWithValue("@employeeId", employeeId);

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Employee? GetEmployeeById(int employeeId)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("SELECT * FROM Employees WHERE employee_id = @employeeId", connection);
                command.Parameters.AddWithValue("@employeeId", employeeId);

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
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                var employees = new List<Employee>();
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("SELECT * FROM Employees", connection);

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
                Console.WriteLine(ex.Message);
                return new List<Employee>();
            }
        }
    }
}