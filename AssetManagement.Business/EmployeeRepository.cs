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
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("INSERT INTO Employees (employee_id ,name, department, email, password) VALUES ( @EmployeeId, @name, @department, @Email, @Password)", connection);
            command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            command.Parameters.AddWithValue("@name", employee.Name);
            command.Parameters.AddWithValue("@department", employee.Department);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@Password", employee.Password);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("UPDATE Employees SET name = @name, department = @department, email = @Email, password = @Password WHERE employee_id = @employeeId", connection);
            command.Parameters.AddWithValue("@name", employee.Name);
            command.Parameters.AddWithValue("@department", employee.Department);
            command.Parameters.AddWithValue("@Email", employee.Email);
            command.Parameters.AddWithValue("@Password", employee.Password);
            command.Parameters.AddWithValue("@employeeId", employee.EmployeeId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool DeleteEmployee(int employeeId)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("DELETE FROM Employees WHERE employee_id = @employeeId", connection);
            command.Parameters.AddWithValue("@employeeId", employeeId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("SELECT * FROM Employees WHERE employee_id = @employeeId", connection);
            command.Parameters.AddWithValue("@employeeId", employeeId);

            connection.Open();
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

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            using (var connection = DBConnection.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Employees", connection);

                connection.Open();
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
            }
            return employees;
        }
    }
}
