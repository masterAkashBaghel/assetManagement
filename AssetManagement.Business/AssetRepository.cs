using AssetManagement.Entities;
using AssetManagement.Util;
using System.Data.SqlClient;
using AssetManagement.Exceptions;
namespace AssetManagement.Business
{
    // Class to interact with the Assets table in the database implementing the IAssetRepository interface
    public class AssetRepository : IAssetRepository
    {
        // Method to add an asset to the database
        public bool AddAsset(Asset asset)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to insert the asset into the database
                var command = new SqlCommand("INSERT INTO Assets (asset_id, name, type, serial_number, purchase_date, location, status, owner_id) VALUES (@AssetId, @name, @type, @serialNumber, @purchaseDate, @location, @status, @ownerId)", connection);
                // Add the parameters to the command
                command.Parameters.AddWithValue("@AssetId", asset.AssetId);
                command.Parameters.AddWithValue("@name", asset.Name);
                command.Parameters.AddWithValue("@type", asset.Type);
                command.Parameters.AddWithValue("@serialNumber", asset.SerialNumber);
                command.Parameters.AddWithValue("@purchaseDate", asset.PurchaseDate);
                command.Parameters.AddWithValue("@location", asset.Location);
                command.Parameters.AddWithValue("@status", asset.Status);
                command.Parameters.AddWithValue("@ownerId", asset.OwnerId);

                // Execute the command and return true if successful
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // Log the error and return false
                Console.WriteLine($"Error adding asset: {ex.Message}");
                return false;
            }
        }
        // Method to update an asset in the database
        public bool UpdateAsset(Asset asset)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to update the asset in the database
                var command = new SqlCommand("UPDATE Assets SET name = @name, type = @type, serial_number = @serialNumber, purchase_date = @purchaseDate, location = @location, status = @status, owner_id = @ownerId WHERE asset_id = @assetId", connection);
                // Add the parameters to the command
                command.Parameters.AddWithValue("@name", asset.Name);
                command.Parameters.AddWithValue("@type", asset.Type);
                command.Parameters.AddWithValue("@serialNumber", asset.SerialNumber);
                command.Parameters.AddWithValue("@purchaseDate", asset.PurchaseDate);
                command.Parameters.AddWithValue("@location", asset.Location);
                command.Parameters.AddWithValue("@status", asset.Status);
                command.Parameters.AddWithValue("@ownerId", asset.OwnerId);
                command.Parameters.AddWithValue("@assetId", asset.AssetId);
                // Execute the command and return true if successful
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                AssetNotFoundException assetNotFoundException = new($"Asset with ID {asset.AssetId} not found", ex);
                throw assetNotFoundException;
            }
        }

        // Method to delete an asset from the database
        public bool DeleteAsset(int assetId)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to delete the asset from the database
                var command = new SqlCommand("DELETE FROM Assets WHERE asset_id = @assetId", connection);
                // Add the parameter to the command
                command.Parameters.AddWithValue("@assetId", assetId);
                // Execute the command and return true if successful
                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                //   throw an AssetNotFoundException if the asset is not found
                AssetNotFoundException assetNotFoundException = new($"Asset with ID {assetId} not found", ex);
                throw assetNotFoundException;
            }
        }

        // Method to retrieve an asset by its ID
        public Asset? GetAssetById(int assetId)
        {
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to select the asset by its ID
                var command = new SqlCommand("SELECT * FROM Assets WHERE asset_id = @assetId", connection);
                // Add the parameter to the command
                command.Parameters.AddWithValue("@assetId", assetId);

                // Execute the command and return the asset if found
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Asset
                    {
                        AssetId = (int)reader["asset_id"],
                        Name = (string)reader["name"],
                        Type = (string)reader["type"],
                        SerialNumber = (string)reader["serial_number"],
                        PurchaseDate = (DateTime)reader["purchase_date"],
                        Location = (string)reader["location"],
                        Status = (string)reader["status"],
                        OwnerId = (int)reader["owner_id"]
                    };
                }
                // Return null if the asset is not found
                return null;
            }
            catch (Exception ex)
            {
                //  throw an AssetNotFoundException if the asset is not found
                AssetNotFoundException assetNotFoundException = new($"Asset with ID {assetId} not found", ex);
                throw assetNotFoundException;
            }
        }

        // Method to retrieve all assets, returning an IEnumerable of Asset objects representing the assets in the database
        public IEnumerable<Asset> GetAllAssets()
        {
            // Create a list to store the assets
            var assets = new List<Asset>();
            try
            {
                // Get a connection to the database using the DBConnection class and the GetConnection method using a using statement, which will automatically close the connection
                using var connection = DBConnection.GetConnection();
                // Create a command to select all assets
                var command = new SqlCommand("SELECT * FROM Assets", connection);

                // Execute the command and add each asset to the list
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    assets.Add(new Asset
                    {
                        AssetId = (int)reader["asset_id"],
                        Name = (string)reader["name"],
                        Type = (string)reader["type"],
                        SerialNumber = (string)reader["serial_number"],
                        PurchaseDate = (DateTime)reader["purchase_date"],
                        Location = (string)reader["location"],
                        Status = (string)reader["status"],
                        OwnerId = (int)reader["owner_id"]
                    });
                }
            }
            catch (Exception ex)
            {
                // Log the error and return an empty list
                Console.WriteLine($"Error retrieving all assets: {ex.Message}");
            }
            return assets;
        }
    }
}