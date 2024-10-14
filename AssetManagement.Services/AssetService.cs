using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;

namespace AssetManagement.Services
{
    // Service class for the AssetRepository class, contains methods for adding, updating, deleting, and retrieving assets
    public class AssetService
    {

        //  instance of the AssetRepository class to be used in the service
        private readonly AssetRepository _assetRepository;

        // Constructor for the AssetService class that takes an AssetRepository object as a parameter
        public AssetService(AssetRepository assetRepository)
        {
            // Assign the parameter to the instance of the AssetRepository class
            _assetRepository = assetRepository;
        }

        // Method to add an asset to the repository
        public bool AddAsset(Asset asset)
        {
            // call the AddAsset method of the AssetRepository class and return the result
            return _assetRepository.AddAsset(asset);
        }

        // Method to update an asset in the repository
        public bool UpdateAsset(Asset asset)
        {
            // check if the asset exists in the repository
            if (_assetRepository.GetAssetById(asset.AssetId) == null)
            {
                // throw an AssetNotFoundException if the asset does not exist
                throw new AssetNotFoundException(asset.AssetId);
            }
            // call the UpdateAsset method of the AssetRepository class and return the result
            return _assetRepository.UpdateAsset(asset);
        }

        // Method to delete an asset from the repository
        public bool DeleteAsset(int assetId)
        {
            // check if the asset exists in the repository
            if (_assetRepository.GetAssetById(assetId) == null)
            {
                // throw an AssetNotFoundException if the asset does not exist
                throw new AssetNotFoundException(assetId);
            }
            // call the DeleteAsset method of the AssetRepository class and return the result
            return _assetRepository.DeleteAsset(assetId);
        }

        // Method to get an asset by its ID from the repository
        public Asset GetAssetById(int assetId)
        {
            // check if the asset exists in the repository by calling the GetAssetById method of the AssetRepository class
            if (_assetRepository.GetAssetById(assetId) == null)
            {
                // throw an AssetNotFoundException if the asset does not exist
                throw new AssetNotFoundException(assetId);
            }
            // return the asset from the repository by calling the GetAssetById method of the AssetRepository class
            return _assetRepository.GetAssetById(assetId);
        }

        // Method to get all assets from the repository
        public IEnumerable<Asset> GetAllAssets()
        {
            // return all assets from the repository by calling the GetAllAssets method of the AssetRepository class
            return _assetRepository.GetAllAssets();
        }
    }
}