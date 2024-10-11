using AssetManagement.Entities;
using AssetManagement.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AssetManagement.Business
{
    public class AssetRepository : IAssetRepository
    {
        public bool AddAsset(Asset asset)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("INSERT INTO Assets (asset_id, name, type, serial_number, purchase_date, location, status, owner_id) VALUES (@AssetId, @name, @type, @serialNumber, @purchaseDate, @location, @status, @ownerId)", connection);
                command.Parameters.AddWithValue("@AssetId", asset.AssetId);
                command.Parameters.AddWithValue("@name", asset.Name);
                command.Parameters.AddWithValue("@type", asset.Type);
                command.Parameters.AddWithValue("@serialNumber", asset.SerialNumber);
                command.Parameters.AddWithValue("@purchaseDate", asset.PurchaseDate);
                command.Parameters.AddWithValue("@location", asset.Location);
                command.Parameters.AddWithValue("@status", asset.Status);
                command.Parameters.AddWithValue("@ownerId", asset.OwnerId);


                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding asset: {ex.Message}");
                return false;
            }
        }

        public bool UpdateAsset(Asset asset)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("UPDATE Assets SET name = @name, type = @type, serial_number = @serialNumber, purchase_date = @purchaseDate, location = @location, status = @status, owner_id = @ownerId WHERE asset_id = @assetId", connection);
                command.Parameters.AddWithValue("@name", asset.Name);
                command.Parameters.AddWithValue("@type", asset.Type);
                command.Parameters.AddWithValue("@serialNumber", asset.SerialNumber);
                command.Parameters.AddWithValue("@purchaseDate", asset.PurchaseDate);
                command.Parameters.AddWithValue("@location", asset.Location);
                command.Parameters.AddWithValue("@status", asset.Status);
                command.Parameters.AddWithValue("@ownerId", asset.OwnerId);
                command.Parameters.AddWithValue("@assetId", asset.AssetId);

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating asset: {ex.Message}");
                return false;
            }
        }

        public bool DeleteAsset(int assetId)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("DELETE FROM Assets WHERE asset_id = @assetId", connection);
                command.Parameters.AddWithValue("@assetId", assetId);

                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting asset: {ex.Message}");
                return false;
            }
        }

        public Asset? GetAssetById(int assetId)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("SELECT * FROM Assets WHERE asset_id = @assetId", connection);
                command.Parameters.AddWithValue("@assetId", assetId);


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
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving asset: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            var assets = new List<Asset>();
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("SELECT * FROM Assets", connection);

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
                Console.WriteLine($"Error retrieving all assets: {ex.Message}");
            }
            return assets;
        }
    }
}