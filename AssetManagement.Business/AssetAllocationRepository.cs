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
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("INSERT INTO AssetAllocations (allocation_id, asset_id, employee_id, allocation_date, return_date) VALUES (@AllocationId, @assetId, @employeeId, @allocationDate, @returnDate)", connection);
                command.Parameters.AddWithValue("@AllocationId", assetAllocation.AllocationId);
                command.Parameters.AddWithValue("@assetId", assetAllocation.AssetId);
                command.Parameters.AddWithValue("@employeeId", assetAllocation.EmployeeId);
                command.Parameters.AddWithValue("@allocationDate", assetAllocation.AllocationDate);
                command.Parameters.AddWithValue("@returnDate", (object)assetAllocation.ReturnDate ?? DBNull.Value);


                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error allocating asset: {ex.Message}");
                return false;
            }
        }

        public bool DeallocateAsset(int allocationId, DateTime returnDate)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("UPDATE AssetAllocations SET return_date = @returnDate WHERE allocation_id = @allocationId", connection);
                command.Parameters.AddWithValue("@returnDate", returnDate);
                command.Parameters.AddWithValue("@allocationId", allocationId);


                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deallocating asset: {ex.Message}");
                return false;
            }
        }

        public AssetAllocation? GetAssetAllocationById(int allocationId)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("SELECT * FROM AssetAllocations WHERE allocation_id = @allocationId", connection);
                command.Parameters.AddWithValue("@allocationId", allocationId);


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
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving asset allocation: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<AssetAllocation> GetAllAssetAllocations()
        {
            var assetAllocations = new List<AssetAllocation>();
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("SELECT * FROM AssetAllocations", connection);


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
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all asset allocations: {ex.Message}");
            }
            return assetAllocations;
        }


        // public bool ReserveAsset(int assetId, int employeeId, string reservationDate, string startDate, string endDate)
        // {
        //     try
        //     {
        //         using var connection = DBConnection.GetConnection();
        //         var command = new SqlCommand("INSERT INTO AssetReservations (asset_id, employee_id, reservation_date, start_date, end_date) VALUES (@assetId, @employeeId, @reservationDate, @startDate, @endDate)", connection);
        //         command.Parameters.AddWithValue("@assetId", assetId);
        //         command.Parameters.AddWithValue("@employeeId", employeeId);
        //         command.Parameters.AddWithValue("@reservationDate", reservationDate);
        //         command.Parameters.AddWithValue("@startDate", startDate);
        //         command.Parameters.AddWithValue("@endDate", endDate);


        //         return command.ExecuteNonQuery() > 0;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error reserving asset: {ex.Message}");
        //         return false;
        //     }
        // }

        // public bool WithdrawReservation(int reservationId)
        // {
        //     try
        //     {
        //         using var connection = DBConnection.GetConnection();
        //         var command = new SqlCommand("DELETE FROM AssetReservations WHERE reservation_id = @reservationId", connection);
        //         command.Parameters.AddWithValue("@reservationId", reservationId);


        //         return command.ExecuteNonQuery() > 0;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error withdrawing reservation: {ex.Message}");
        //         return false;
        //     }
        // }
    }
}