using System;
using AssetManagement.Services;
using AssetManagement.Entities;
using AssetManagement.Business;

namespace AssetManagement.UI
{
    public static class AssetAllocationMenu
    {
        public static void Show()
        {
            var assetAllocationService = new AssetAllocationService(new AssetAllocationRepository());

            while (true)
            {
                Console.WriteLine("Asset Allocation Management");
                Console.WriteLine("1. Allocate Asset");
                Console.WriteLine("2. Deallocate Asset");
                Console.WriteLine("3. View Asset Allocation by ID");
                Console.WriteLine("4. View All Asset Allocations");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AllocateAsset(assetAllocationService);
                        break;
                    case "2":
                        DeallocateAsset(assetAllocationService);
                        break;
                    case "3":
                        ViewAssetAllocationById(assetAllocationService);
                        break;
                    case "4":
                        ViewAllAssetAllocations(assetAllocationService);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AllocateAsset(AssetAllocationService assetAllocationService)
        {
            var assetAllocation = new AssetAllocation();
            Console.Write("Enter Asset ID: ");
            assetAllocation.AssetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee ID: ");
            assetAllocation.EmployeeId = int.Parse(Console.ReadLine());
            Console.Write("Enter Allocation Date (yyyy-mm-dd): ");
            assetAllocation.AllocationDate = DateTime.Parse(Console.ReadLine());

            if (assetAllocationService.AllocateAsset(assetAllocation))
            {
                Console.WriteLine("Asset allocated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to allocate asset.");
            }
        }

        static void DeallocateAsset(AssetAllocationService assetAllocationService)
        {
            Console.Write("Enter Allocation ID: ");
            var allocationId = int.Parse(Console.ReadLine());
            Console.Write("Enter Return Date (yyyy-mm-dd): ");
            var returnDate = DateTime.Parse(Console.ReadLine());

            if (assetAllocationService.DeallocateAsset(allocationId, returnDate))
            {
                Console.WriteLine("Asset deallocated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to deallocate asset.");
            }
        }

        static void ViewAssetAllocationById(AssetAllocationService assetAllocationService)
        {
            Console.Write("Enter Allocation ID: ");
            var allocationId = int.Parse(Console.ReadLine());

            var assetAllocation = assetAllocationService.GetAssetAllocationById(allocationId);
            if (assetAllocation != null)
            {
                Console.WriteLine($"ID: {assetAllocation.AllocationId}, Asset ID: {assetAllocation.AssetId}, Employee ID: {assetAllocation.EmployeeId}, Allocation Date: {assetAllocation.AllocationDate}, Return Date: {assetAllocation.ReturnDate}");
            }
            else
            {
                Console.WriteLine("Asset allocation not found.");
            }
        }

        static void ViewAllAssetAllocations(AssetAllocationService assetAllocationService)
        {
            var assetAllocations = assetAllocationService.GetAllAssetAllocations();
            foreach (var assetAllocation in assetAllocations)
            {
                Console.WriteLine($"ID: {assetAllocation.AllocationId}, Asset ID: {assetAllocation.AssetId}, Employee ID: {assetAllocation.EmployeeId}, Allocation Date: {assetAllocation.AllocationDate}, Return Date: {assetAllocation.ReturnDate}");
            }
        }
    }
}