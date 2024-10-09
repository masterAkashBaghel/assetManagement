using AssetManagement.Entities;
using AssetManagement.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AssetManagement.Business
{
    public class AssetAllocationRepository : IAssetAllocationRepository
    {
        public bool AllocateAsset(AssetAllocation assetAllocation)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("INSERT INTO AssetAllocations (asset_id, employee_id, allocation_date, return_date) VALUES (@assetId, @employeeId, @allocationDate, @returnDate)", connection);
            command.Parameters.AddWithValue("@assetId", assetAllocation.AssetId);
            command.Parameters.AddWithValue("@employeeId", assetAllocation.EmployeeId);
            command.Parameters.AddWithValue("@allocationDate", assetAllocation.AllocationDate);
            command.Parameters.AddWithValue("@returnDate", (object)assetAllocation.ReturnDate ?? DBNull.Value);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool DeallocateAsset(int allocationId, DateTime returnDate)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("UPDATE AssetAllocations SET return_date = @returnDate WHERE allocation_id = @allocationId", connection);
            command.Parameters.AddWithValue("@returnDate", returnDate);
            command.Parameters.AddWithValue("@allocationId", allocationId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public AssetAllocation GetAssetAllocationById(int allocationId)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("SELECT * FROM AssetAllocations WHERE allocation_id = @allocationId", connection);
            command.Parameters.AddWithValue("@allocationId", allocationId);

            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new AssetAllocation
                {
                    AllocationId = (int)reader["allocation_id"],
                    AssetId = (int)reader["asset_id"],
                    EmployeeId = (int)reader["employee_id"],
                    AllocationDate = (DateTime)reader["allocation_date"],
                    ReturnDate = reader["return_date"] as DateTime?
                };
            }
            return null;
        }

        public IEnumerable<AssetAllocation> GetAllAssetAllocations()
        {
            var assetAllocations = new List<AssetAllocation>();
            using (var connection = DBConnection.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM AssetAllocations", connection);

                connection.Open();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assetAllocations.Add(new AssetAllocation
                    {
                        AllocationId = (int)reader["allocation_id"],
                        AssetId = (int)reader["asset_id"],
                        EmployeeId = (int)reader["employee_id"],
                        AllocationDate = (DateTime)reader["allocation_date"],
                        ReturnDate = reader["return_date"] as DateTime?
                    });
                }
            }
            return assetAllocations;
        }
    }
}