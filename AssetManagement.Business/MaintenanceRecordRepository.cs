using AssetManagement.Entities;
using AssetManagement.Exceptions;
using AssetManagement.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AssetManagement.Business
{
    // Class to interact with the MaintenanceRecords table in the database implementing the IMaintenanceRecordRepository interface
    public class MaintenanceRecordRepository : IMaintenanceRecordRepository
    {

        // Method to add a maintenance record to the database
        public bool AddMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to insert the maintenance record into the database
                var command = new SqlCommand("INSERT INTO MaintenanceRecords ( maintenance_id,   asset_id, maintenance_date, description, cost) VALUES ( @MaintenanceId, @assetId, @maintenanceDate, @description, @cost)", connection);
                // Add the parameters to the command
                command.Parameters.AddWithValue("@MaintenanceId", maintenanceRecord.MaintenanceId);
                command.Parameters.AddWithValue("@assetId", maintenanceRecord.AssetId);
                command.Parameters.AddWithValue("@maintenanceDate", maintenanceRecord.MaintenanceDate);
                command.Parameters.AddWithValue("@description", maintenanceRecord.Description);
                command.Parameters.AddWithValue("@cost", maintenanceRecord.Cost);

                // Execute the command and return true if successful
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // Log the error and throw a MaintenanceException with the error message
                MaintenanceException maintenanceException = new("Failed to add maintenance record", ex);
                throw maintenanceException;
            }
        }

        // Method to update a maintenance record in the database    
        public bool UpdateMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to update the maintenance record in the database
                var command = new SqlCommand("UPDATE MaintenanceRecords SET asset_id = @assetId, maintenance_date = @maintenanceDate, description = @description, cost = @cost WHERE maintenance_id = @maintenanceId", connection);
                // Add the parameters to the command
                command.Parameters.AddWithValue("@assetId", maintenanceRecord.AssetId);
                command.Parameters.AddWithValue("@maintenanceDate", maintenanceRecord.MaintenanceDate);
                command.Parameters.AddWithValue("@description", maintenanceRecord.Description);
                command.Parameters.AddWithValue("@cost", maintenanceRecord.Cost);
                command.Parameters.AddWithValue("@maintenanceId", maintenanceRecord.MaintenanceId);

                // Execute the command and return true if successful
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // Log the error and throw a MaintenanceException with the error message
                MaintenanceException maintenanceException = new("Failed to update maintenance record", ex);
                throw maintenanceException;

            }
        }

        // Method to delete a maintenance record from the database
        public bool DeleteMaintenanceRecord(int maintenanceId)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to delete the maintenance record from the database
                var command = new SqlCommand("DELETE FROM MaintenanceRecords WHERE maintenance_id = @maintenanceId", connection);
                // Add the parameter to the command
                command.Parameters.AddWithValue("@maintenanceId", maintenanceId);

                // Execute the command and return true if successful
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // Log the error and throw a MaintenanceException with the error message
                MaintenanceException maintenanceException = new("Failed to delete maintenance record", ex);
                throw maintenanceException;
            }
        }
        // Method to retrieve a maintenance record by its ID
        public MaintenanceRecord? GetMaintenanceRecordById(int maintenanceId)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to select the maintenance record by its ID
                var command = new SqlCommand("SELECT * FROM MaintenanceRecords WHERE maintenance_id = @maintenanceId", connection);
                // Add the parameter to the command
                command.Parameters.AddWithValue("@maintenanceId", maintenanceId);

                // Execute the command and return the maintenance record if found ,using a using statement to automatically close the reader
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new MaintenanceRecord
                    {
                        MaintenanceId = (int)reader["maintenance_id"],
                        AssetId = (int)reader["asset_id"],
                        MaintenanceDate = (DateTime)reader["maintenance_date"],
                        Description = (string)reader["description"],
                        Cost = (double)(decimal)reader["cost"]
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                // Log the error and throw a MaintenanceException with the error message
                MaintenanceException maintenanceException = new("Failed to retrieve maintenance record", ex);
                throw maintenanceException;
            }
        }
        // Method to retrieve all maintenance records from the database
        public IEnumerable<MaintenanceRecord> GetAllMaintenanceRecords()
        {
            try
            {
                // Create a list to store the maintenance records
                var maintenanceRecords = new List<MaintenanceRecord>();
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using (var connection = DBConnection.GetConnection())
                {
                    // Create a command to select all maintenance records
                    var command = new SqlCommand("SELECT * FROM MaintenanceRecords", connection);
                    // Execute the command and add each maintenance record to the list
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maintenanceRecords.Add(new MaintenanceRecord
                        {
                            MaintenanceId = (int)reader["maintenance_id"],
                            AssetId = (int)reader["asset_id"],
                            MaintenanceDate = (DateTime)reader["maintenance_date"],
                            Description = (string)reader["description"],
                            Cost = (double)(decimal)reader["cost"]
                        });
                    }
                }
                return maintenanceRecords;
            }
            catch (Exception ex)
            {
                // Log the error and throw a MaintenanceException with the error message
                MaintenanceException maintenanceException = new("Failed to retrieve maintenance records", ex);
                throw maintenanceException;
            }
        }

        // Method to perform maintenance on an asset

        public bool PerformMaintenance(int maintenanceId, int assetId, string maintenanceDate, string description, double cost)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to insert the maintenance record into the database
                var command = new SqlCommand("INSERT INTO MaintenanceRecords (maintenance_id,asset_id, maintenance_date, description, cost) VALUES (@maintenanceId,@assetId, @maintenanceDate, @description, @cost)", connection);

                // Add the parameters to the command
                command.Parameters.AddWithValue("@maintenanceId", maintenanceId);
                command.Parameters.AddWithValue("@assetId", assetId);
                command.Parameters.AddWithValue("@maintenanceDate", maintenanceDate);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@cost", cost);

                // Execute the command and return true if successful
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // Log the error and throw a MaintenanceException with the error message
                MaintenanceException maintenanceException = new("Failed to perform maintenance", ex);
                throw maintenanceException;
            }
        }
    }
}