using AssetManagement.Entities;
using System;
using System.Collections.Generic;

namespace AssetManagement.Business
{
    public interface IAssetAllocationRepository
    {
        bool AllocateAsset(AssetAllocation assetAllocation);
        bool DeallocateAsset(int allocationId, DateTime returnDate);
        AssetAllocation GetAssetAllocationById(int allocationId);
        IEnumerable<AssetAllocation> GetAllAssetAllocations();
        // bool ReserveAsset(int assetId, int employeeId, string reservationDate, string startDate, string endDate);
    }
}