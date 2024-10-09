using AssetManagement.Entities;
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
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("INSERT INTO MaintenanceRecords (asset_id, maintenance_date, description, cost) VALUES (@assetId, @maintenanceDate, @description, @cost)", connection);
            command.Parameters.AddWithValue("@assetId", maintenanceRecord.AssetId);
            command.Parameters.AddWithValue("@maintenanceDate", maintenanceRecord.MaintenanceDate);
            command.Parameters.AddWithValue("@description", maintenanceRecord.Description);
            command.Parameters.AddWithValue("@cost", maintenanceRecord.Cost);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("UPDATE MaintenanceRecords SET asset_id = @assetId, maintenance_date = @maintenanceDate, description = @description, cost = @cost WHERE maintenance_id = @maintenanceId", connection);
            command.Parameters.AddWithValue("@assetId", maintenanceRecord.AssetId);
            command.Parameters.AddWithValue("@maintenanceDate", maintenanceRecord.MaintenanceDate);
            command.Parameters.AddWithValue("@description", maintenanceRecord.Description);
            command.Parameters.AddWithValue("@cost", maintenanceRecord.Cost);
            command.Parameters.AddWithValue("@maintenanceId", maintenanceRecord.MaintenanceId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool DeleteMaintenanceRecord(int maintenanceId)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("DELETE FROM MaintenanceRecords WHERE maintenance_id = @maintenanceId", connection);
            command.Parameters.AddWithValue("@maintenanceId", maintenanceId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public MaintenanceRecord GetMaintenanceRecordById(int maintenanceId)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("SELECT * FROM MaintenanceRecords WHERE maintenance_id = @maintenanceId", connection);
            command.Parameters.AddWithValue("@maintenanceId", maintenanceId);

            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new MaintenanceRecord
                {
                    MaintenanceId = (int)reader["maintenance_id"],
                    AssetId = (int)reader["asset_id"],
                    MaintenanceDate = (DateTime)reader["maintenance_date"],
                    Description = (string)reader["description"],
                    Cost = (double)reader["cost"]
                };
            }
            return null;
        }

        public IEnumerable<MaintenanceRecord> GetAllMaintenanceRecords()
        {
            var maintenanceRecords = new List<MaintenanceRecord>();
            using (var connection = DBConnection.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM MaintenanceRecords", connection);

                connection.Open();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    maintenanceRecords.Add(new MaintenanceRecord
                    {
                        MaintenanceId = (int)reader["maintenance_id"],
                        AssetId = (int)reader["asset_id"],
                        MaintenanceDate = (DateTime)reader["maintenance_date"],
                        Description = (string)reader["description"],
                        Cost = (double)reader["cost"]
                    });
                }
            }
            return maintenanceRecords;
        }
    }
}