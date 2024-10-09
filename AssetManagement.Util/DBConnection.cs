using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace AssetManagement.Util
{
    public static class DBConnection
    {
        private static readonly object LockObject = new object();
        private static string _connectionString;

        static DBConnection()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public static SqlConnection GetConnection()
        {
            lock (LockObject)
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}