using AssetManagement.Business;
using AssetManagement.Entities;

namespace AssetManagement.Services
{
    public class AssetAllocationService
    {
        private readonly AssetAllocationRepository _assetAllocationRepository;

        public AssetAllocationService(AssetAllocationRepository assetAllocationRepository)
        {
            _assetAllocationRepository = assetAllocationRepository;
        }

        public bool AllocateAsset(AssetAllocation assetAllocation)
        {
            return _assetAllocationRepository.AllocateAsset(assetAllocation);
        }

        public bool DeallocateAsset(int allocationId, DateTime returnDate)
        {
            return _assetAllocationRepository.DeallocateAsset(allocationId, returnDate);
        }

        public AssetAllocation GetAssetAllocationById(int allocationId)
        {
            return _assetAllocationRepository.GetAssetAllocationById(allocationId);
        }

        public IEnumerable<AssetAllocation> GetAllAssetAllocations()
        {
            return _assetAllocationRepository.GetAllAssetAllocations();
        }
    }
}
