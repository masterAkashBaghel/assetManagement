using AssetManagement.Entities;
using AssetManagement.Util;
using System.Data.SqlClient;

namespace AssetManagement.Business
{
    public class AssetRepository : IAssetRepository
    {
        public bool AddAsset(Asset asset)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("INSERT INTO Assets (name, type, serial_number, purchase_date, location, status, owner_id) VALUES (@name, @type, @serialNumber, @purchaseDate, @location, @status, @ownerId)", connection);
            command.Parameters.AddWithValue("@name", asset.Name);
            command.Parameters.AddWithValue("@type", asset.Type);
            command.Parameters.AddWithValue("@serialNumber", asset.SerialNumber);
            command.Parameters.AddWithValue("@purchaseDate", asset.PurchaseDate);
            command.Parameters.AddWithValue("@location", asset.Location);
            command.Parameters.AddWithValue("@status", asset.Status);
            command.Parameters.AddWithValue("@ownerId", asset.OwnerId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateAsset(Asset asset)
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

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool DeleteAsset(int assetId)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("DELETE FROM Assets WHERE asset_id = @assetId", connection);
            command.Parameters.AddWithValue("@assetId", assetId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public Asset GetAssetById(int assetId)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("SELECT * FROM Assets WHERE asset_id = @assetId", connection);
            command.Parameters.AddWithValue("@assetId", assetId);

            connection.Open();
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

        public IEnumerable<Asset> GetAllAssets()
        {
            var assets = new List<Asset>();
            using (var connection = DBConnection.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Assets", connection);

                connection.Open();
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
            return assets;
        }
    }
}