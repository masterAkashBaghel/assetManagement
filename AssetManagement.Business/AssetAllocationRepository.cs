using AssetManagement.Entities;
using AssetManagement.Util;
using System.Data.SqlClient;
using AssetManagement.Exceptions;

namespace AssetManagement.Business
{
    // Class to interact with the AssetAllocations table in the database implementing the IAssetAllocationRepository interface
    public class AssetAllocationRepository : IAssetAllocationRepository
    {
        // Method to allocate an asset to an employee
        public bool AllocateAsset(AssetAllocation assetAllocation)
        {
            try
            {
                // Get a connection to the database
                using var connection = DBConnection.GetConnection();
                // Create a command to insert the asset allocation into the database
                var command = new SqlCommand("INSERT INTO AssetAllocations (allocation_id, asset_id, employee_id, allocation_date, return_date) VALUES (@AllocationId, @assetId, @employeeId, @allocationDate, @returnDate)", connection);
                // Add the parameters to the command
                command.Parameters.AddWithValue("@AllocationId", assetAllocation.AllocationId);
                command.Parameters.AddWithValue("@assetId", assetAllocation.AssetId);
                command.Parameters.AddWithValue("@employeeId", assetAllocation.EmployeeId);
                command.Parameters.AddWithValue("@allocationDate", assetAllocation.AllocationDate);
                command.Parameters.AddWithValue("@returnDate", (object)assetAllocation.ReturnDate ?? DBNull.Value);

                // Execute the command and return true if successful
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // Log the error and return false
                Console.WriteLine($"Error allocating asset: {ex.Message}");
                return false;
            }
        }

        // Method to deallocate an asset from an employee
        public bool DeallocateAsset(int allocationId, DateTime returnDate)
        {
            try
            {
                // Get a connection to the database
                using var connection = DBConnection.GetConnection();
                // Create a command to update the return date of the asset allocation
                var command = new SqlCommand("UPDATE AssetAllocations SET return_date = @returnDate WHERE allocation_id = @allocationId", connection);
                // Add the parameters to the command
                command.Parameters.AddWithValue("@returnDate", returnDate);
                command.Parameters.AddWithValue("@allocationId", allocationId);

                // Execute the command and return true if successful
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                AssetAllocationNotFoundException assetAllocationNotFoundException = new("Asset Allocation not found", ex);
                throw assetAllocationNotFoundException;

            }
        }

        // Method to retrieve an asset allocation by its ID
        public AssetAllocation? GetAssetAllocationById(int allocationId)
        {
            try
            {
                // Get a connection to the database
                using var connection = DBConnection.GetConnection();
                // Create a command to select the asset allocation by its ID
                var command = new SqlCommand("SELECT * FROM AssetAllocations WHERE allocation_id = @allocationId", connection);
                // Add the parameter to the command
                command.Parameters.AddWithValue("@allocationId", allocationId);

                // Execute the command and return the asset allocation if found
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
                // Using the AssetAllocationNotFoundException class to log the error and return null
                AssetAllocationNotFoundException assetAllocationNotFoundException = new("Asset Allocation not found", ex);
                throw assetAllocationNotFoundException;
            }
        }

        // Method to retrieve all asset allocations
        public IEnumerable<AssetAllocation> GetAllAssetAllocations()
        {
            var assetAllocations = new List<AssetAllocation>();
            try
            {
                // Get a connection to the database using a using statement to ensure it is disposed of correctly
                using var connection = DBConnection.GetConnection();
                // Create a command to select all asset allocations
                var command = new SqlCommand("SELECT * FROM AssetAllocations", connection);

                // Execute the command and add each asset allocation to the list
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Create a new AssetAllocation object and add it to the list
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
                AssetAllocationNotFoundException assetAllocationNotFoundException = new("Asset Allocation not found", ex);
                throw assetAllocationNotFoundException;
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