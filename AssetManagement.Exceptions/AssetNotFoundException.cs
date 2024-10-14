using System;

namespace AssetManagement.Exceptions
{
    // Exception class for when an asset is not found
    public class AssetNotFoundException : Exception
    {
        // The ID of the asset that was not found
        public int AssetId { get; }
        // Default constructor
        public AssetNotFoundException() : base("Asset not found.")
        {
        }
        // Constructor with asset ID parameter
        public AssetNotFoundException(int assetId)
            : base($"Asset with ID {assetId} not found.")
        {
            AssetId = assetId;
        }

        // Constructor with message parameter

        public AssetNotFoundException(string message) : base(message)
        {
        }

        // Constructor with message and inner exception parameters

        public AssetNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // Constructor with asset ID, message, and inner exception parameters

        public AssetNotFoundException(int assetId, string message)
            : base(message)
        {
            AssetId = assetId;
        }

        // Constructor with asset ID, message, and inner exception parameters
        public AssetNotFoundException(int assetId, string message, Exception innerException)
            : base(message, innerException)
        {
            AssetId = assetId;
        }

        // Override the ToString method to include the asset ID
        public override string ToString()
        {
            return $"AssetNotFoundException: {Message}, AssetId: {AssetId}";
        }
    }
}