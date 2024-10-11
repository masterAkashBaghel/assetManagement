using AssetManagement.Entities;
using AssetManagement.Exceptions;
using AssetManagement.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AssetManagement.Business
{
    public class MaintenanceRecordRepository : IMaintenanceRecordRepository
    {
        public bool AddMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("INSERT INTO MaintenanceRecords ( maintenance_id,   asset_id, maintenance_date, description, cost) VALUES ( @MaintenanceId, @assetId, @maintenanceDate, @description, @cost)", connection);
                command.Parameters.AddWithValue("@MaintenanceId", maintenanceRecord.MaintenanceId);
                command.Parameters.AddWithValue("@assetId", maintenanceRecord.AssetId);
                command.Parameters.AddWithValue("@maintenanceDate", maintenanceRecord.MaintenanceDate);
                command.Parameters.AddWithValue("@description", maintenanceRecord.Description);
                command.Parameters.AddWithValue("@cost", maintenanceRecord.Cost);


                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to add maintenance record.", ex);
            }
        }

        public bool UpdateMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("UPDATE MaintenanceRecords SET asset_id = @assetId, maintenance_date = @maintenanceDate, description = @description, cost = @cost WHERE maintenance_id = @maintenanceId", connection);
                command.Parameters.AddWithValue("@assetId", maintenanceRecord.AssetId);
                command.Parameters.AddWithValue("@maintenanceDate", maintenanceRecord.MaintenanceDate);
                command.Parameters.AddWithValue("@description", maintenanceRecord.Description);
                command.Parameters.AddWithValue("@cost", maintenanceRecord.Cost);
                command.Parameters.AddWithValue("@maintenanceId", maintenanceRecord.MaintenanceId);


                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to update maintenance record.", ex);
            }
        }

        public bool DeleteMaintenanceRecord(int maintenanceId)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("DELETE FROM MaintenanceRecords WHERE maintenance_id = @maintenanceId", connection);
                command.Parameters.AddWithValue("@maintenanceId", maintenanceId);


                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to delete maintenance record.", ex);
            }
        }

        public MaintenanceRecord? GetMaintenanceRecordById(int maintenanceId)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("SELECT * FROM MaintenanceRecords WHERE maintenance_id = @maintenanceId", connection);
                command.Parameters.AddWithValue("@maintenanceId", maintenanceId);


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
                throw new MaintenanceException("Failed to retrieve maintenance record by ID.", ex);
            }
        }

        public IEnumerable<MaintenanceRecord> GetAllMaintenanceRecords()
        {
            try
            {
                var maintenanceRecords = new List<MaintenanceRecord>();
                using (var connection = DBConnection.GetConnection())
                {
                    var command = new SqlCommand("SELECT * FROM MaintenanceRecords", connection);

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
                throw new MaintenanceException("Failed to retrieve all maintenance records.", ex);
            }
        }

        public bool PerformMaintenance(int assetId, string maintenanceDate, string description, double cost)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("INSERT INTO MaintenanceRecords (asset_id, maintenance_date, description, cost) VALUES (@assetId, @maintenanceDate, @description, @cost)", connection);
                command.Parameters.AddWithValue("@assetId", assetId);
                command.Parameters.AddWithValue("@maintenanceDate", maintenanceDate);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@cost", cost);


                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to perform maintenance.", ex);
            }
        }
    }
}