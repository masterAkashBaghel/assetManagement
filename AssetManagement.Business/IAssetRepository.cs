using AssetManagement.Entities;
using System.Collections.Generic;

namespace AssetManagement.Business
{
    // Interface for the AssetRepository class
    public interface IAssetRepository
    {
        bool AddAsset(Asset asset);
        bool UpdateAsset(Asset asset);
        bool DeleteAsset(int assetId);
        Asset GetAssetById(int assetId);
        IEnumerable<Asset> GetAllAssets();
    }
}
