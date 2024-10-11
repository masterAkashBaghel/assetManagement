﻿using System;
using System.Data.SqlClient;
using System.IO;

namespace AssetManagement.Util
{
    public static class DBConnection
    {
        private static string _connectionString;

        static DBConnection()
        {
            try
            {
                // Path to the file containing the connection string
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "sqlString");

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("The connection string file 'sqlString' was not found on the desktop.");
                }

                _connectionString = File.ReadAllText(filePath).Trim();

                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new InvalidOperationException("The connection string in 'sqlString' is empty.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing DBConnection: {ex.Message}");
                throw;
            }
        }

        // Method to return an open SqlConnection using a using statement
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open(); // Open the connection before returning
            return connection;  // Let the caller manage disposing of the connection
        }
    }
}