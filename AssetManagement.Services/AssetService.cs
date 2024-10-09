using AssetManagement.Business;
using AssetManagement.Entities;

namespace AssetManagement.Services
{
    public class AssetService
    {
        private readonly AssetRepository _assetRepository;

        public AssetService(AssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public bool AddAsset(Asset asset)
        {
            return _assetRepository.AddAsset(asset);
        }

        public bool UpdateAsset(Asset asset)
        {
            return _assetRepository.UpdateAsset(asset);
        }

        public bool DeleteAsset(int assetId)
        {
            return _assetRepository.DeleteAsset(assetId);
        }

        public Asset GetAssetById(int assetId)
        {
            return _assetRepository.GetAssetById(assetId);
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            return _assetRepository.GetAllAssets();
        }
    }
}