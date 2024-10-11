using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions.AssetManagement.Exceptions;

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
            try
            {
                return _assetAllocationRepository.AllocateAsset(assetAllocation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error allocating asset: {ex.Message}");
                throw new AssetAllocationException("Failed to allocate asset.", ex);
            }
        }

        public bool DeallocateAsset(int allocationId, DateTime returnDate)
        {
            try
            {
                return _assetAllocationRepository.DeallocateAsset(allocationId, returnDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deallocating asset: {ex.Message}");
                throw new AssetAllocationException("Failed to deallocate asset.", ex);
            }
        }

        public AssetAllocation GetAssetAllocationById(int allocationId)
        {
            try
            {
                return _assetAllocationRepository.GetAssetAllocationById(allocationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving asset allocation: {ex.Message}");
                throw new AssetAllocationException("Failed to retrieve asset allocation.", ex);
            }
        }

        public IEnumerable<AssetAllocation> GetAllAssetAllocations()
        {
            try
            {
                return _assetAllocationRepository.GetAllAssetAllocations();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all asset allocations: {ex.Message}");
                throw new AssetAllocationException("Failed to retrieve all asset allocations.", ex);
            }
        }

        // public bool ReserveAsset(int assetId, int employeeId, string reservationDate, string startDate, string endDate)
        // {
        //     try
        //     {
        //         return _assetAllocationRepository.ReserveAsset(assetId, employeeId, reservationDate, startDate, endDate);
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error reserving asset: {ex.Message}");
        //         throw new AssetReservationException("Failed to reserve asset.", ex);
        //     }
        // }

        // public bool WithdrawReservation(int reservationId)
        // {
        //     try
        //     {
        //         return _assetAllocationRepository.WithdrawReservation(reservationId);
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error withdrawing reservation: {ex.Message}");
        //         throw new AssetReservationException("Failed to withdraw reservation.", ex);
        //     }
        // }
    }



}