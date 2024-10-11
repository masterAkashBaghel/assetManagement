using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;

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
            if (_assetRepository.GetAssetById(asset.AssetId) == null)
            {
                throw new AssetNotFoundException(asset.AssetId);
            }
            return _assetRepository.UpdateAsset(asset);
        }

        public bool DeleteAsset(int assetId)
        {
            if (_assetRepository.GetAssetById(assetId) == null)
            {
                throw new AssetNotFoundException(assetId);
            }
            return _assetRepository.DeleteAsset(assetId);
        }

        public Asset GetAssetById(int assetId)
        {
            if (_assetRepository.GetAssetById(assetId) == null)
            {
                throw new AssetNotFoundException(assetId);
            }
            return _assetRepository.GetAssetById(assetId);
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            return _assetRepository.GetAllAssets();
        }
    }
}