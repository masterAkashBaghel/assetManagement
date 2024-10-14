// using System;
// using System.Data.SqlClient;
// using System.IO;

// namespace AssetManagement.Util
// {
//     public static class DBConnection
//     {
//         private static string _connectionString;

//         static DBConnection()
//         {
//             try
//             {
//                 // Path to the file containing the connection string
//                 string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "sqlString");

//                 if (!File.Exists(filePath))
//                 {
//                     throw new FileNotFoundException("The connection string file 'sqlString' was not found on the desktop.");
//                 }

//                 _connectionString = File.ReadAllText(filePath).Trim();

//                 if (string.IsNullOrEmpty(_connectionString))
//                 {
//                     throw new InvalidOperationException("The connection string in 'sqlString' is empty.");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Error initializing DBConnection: {ex.Message}");
//                 throw;
//             }
//         }

//         // Method to return an open SqlConnection using a using statement
//         public static SqlConnection GetConnection()
//         {
//             SqlConnection connection = new SqlConnection(_connectionString);
//             connection.Open(); // Open the connection before returning
//             return connection;  // Let the caller manage disposing of the connection
//         }
//     }
// }


using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace AssetManagement.Util
{
    public static class DBConnection
    {
        // Static field to hold the connection string
        private static string _connectionString;

        // Static constructor to initialize the connection string
        static DBConnection()
        {
            // Create a configuration builder to read the appsettings.json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Set the base path to the application's base directory
                .AddJsonFile("appsettings.json") // Add the appsettings.json file to the configuration
                .Build(); // Build the configuration

            // Retrieve the connection string named "DefaultConnection" from the configuration
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Method to get an open SQL connection
        public static SqlConnection GetConnection()
        {
            // Create a new SqlConnection using the connection string
            SqlConnection connection = new SqlConnection(_connectionString);
            // Open the connection
            connection.Open();
            // Return the open connection
            return connection;
        }
    }
}