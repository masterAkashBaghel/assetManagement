using AssetManagement.Business;
using AssetManagement.Entities;

namespace AssetManagement.Services
{
    // Class to interact with the AssetAllocationRepository class and perform operations on asset allocations
    public class AssetAllocationService
    {
        // Private field to hold an instance of the AssetAllocationRepository class
        private readonly AssetAllocationRepository _assetAllocationRepository;


        // Constructor to create an instance of the AssetAllocationService class with an instance of the AssetAllocationRepository class
        public AssetAllocationService(AssetAllocationRepository assetAllocationRepository)
        {
            // Assign the parameter to the private field
            _assetAllocationRepository = assetAllocationRepository;
        }

        // Method to allocate an asset to an employee
        public bool AllocateAsset(AssetAllocation assetAllocation)
        {
            try
            {
                // Call the AllocateAsset method of the AssetAllocationRepository class and return the result
                return _assetAllocationRepository.AllocateAsset(assetAllocation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error allocating asset: {ex.Message}");
                return false;
            }
        }

        // Method to deallocate an asset from an employee
        public bool DeallocateAsset(int allocationId, DateTime returnDate)
        {
            try
            {
                // Call the DeallocateAsset method of the AssetAllocationRepository class and return the result
                return _assetAllocationRepository.DeallocateAsset(allocationId, returnDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deallocating asset: {ex.Message}");
                return false;
            }
        }

        // Method to get an asset allocation by ID  

        public AssetAllocation GetAssetAllocationById(int allocationId)
        {
            try
            {
                // Call the GetAssetAllocationById method of the AssetAllocationRepository class and return the result
                return _assetAllocationRepository.GetAssetAllocationById(allocationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving asset allocation: {ex.Message}");
                return null;
            }
        }


        // Method to get all asset allocations , returns a list of AssetAllocation objects
        public IEnumerable<AssetAllocation> GetAllAssetAllocations()
        {
            try
            {
                // Call the GetAllAssetAllocations method of the AssetAllocationRepository class and return the result
                return _assetAllocationRepository.GetAllAssetAllocations();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all asset allocations: {ex.Message}");
                return null;
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