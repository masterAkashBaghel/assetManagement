using System;

namespace AssetManagement.Exceptions
{
    public class AssetNotFoundException : Exception
    {
        public int AssetId { get; }

        public AssetNotFoundException() : base("Asset not found.")
        {
        }

        public AssetNotFoundException(int assetId)
            : base($"Asset with ID {assetId} not found.")
        {
            AssetId = assetId;
        }

        public AssetNotFoundException(string message) : base(message)
        {
        }

        public AssetNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AssetNotFoundException(int assetId, string message)
            : base(message)
        {
            AssetId = assetId;
        }

        public AssetNotFoundException(int assetId, string message, Exception innerException)
            : base(message, innerException)
        {
            AssetId = assetId;
        }

        public override string ToString()
        {
            return $"AssetNotFoundException: {Message}, AssetId: {AssetId}";
        }
    }
}