using System;
using AssetManagement.Services;
using AssetManagement.Entities;
using AssetManagement.Business;

namespace AssetManagement.UI
{
    public static class AssetAllocationMenu
    {

        // Method to display the Asset Allocation menu, take user input, and call the appropriate methods
        public static void Show()
        {
            // Create an instance of the AssetAllocationService class with an instance of the AssetAllocationRepository class
            var assetAllocationService = new AssetAllocationService(new AssetAllocationRepository());

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("-----WELCOME TO ASSET ALLOCATION DASHBOARD------");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1. Allocate Asset");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("2. Deallocate Asset");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("3. View Asset Allocation by ID");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("4. View All Asset Allocations");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("5. Back to Main Menu");
                Console.WriteLine("---------------------------------------------");

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

        // Method to allocate an asset to an employee
        static void AllocateAsset(AssetAllocationService assetAllocationService)
        {
            // Create a new instance of the AssetAllocation class to hold the allocation details
            var assetAllocation = new AssetAllocation();

            // Prompt the user to enter the asset ID, employee ID, and allocation date
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("----------ALLOCATE ASSET---------");
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

        // Method to deallocate an asset from an employee, prompt the user to enter the allocation ID and return date
        // Call the DeallocateAsset method of the AssetAllocationService class and display, this method receives the AssetAllocationService instance as a parameter
        static void DeallocateAsset(AssetAllocationService assetAllocationService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("----------DEALLOCATE ASSET---------");
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



        // Method to view an asset allocation by its ID
        // Prompt the user to enter the allocation ID, call the GetAssetAllocationById method of the AssetAllocationService class, and display the result
        static void ViewAssetAllocationById(AssetAllocationService assetAllocationService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("----------VIEW ASSET ALLOCATION BY ID---------");
            Console.Write("Enter Allocation ID: ");
            var allocationId = int.Parse(Console.ReadLine());

            var assetAllocation = assetAllocationService.GetAssetAllocationById(allocationId);
            if (assetAllocation != null)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("| {0,-15} | {1,-10} | {2,-10} | {3,-15} | {4,-15} |",
                    "Allocation ID", "Asset ID", "Employee ID", "Allocation Date", "Return Date");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("| {0,-15} | {1,-10} | {2,-10} | {3,-15} | {4,-15} |",
                    assetAllocation.AllocationId, assetAllocation.AssetId, assetAllocation.EmployeeId, assetAllocation.AllocationDate.ToString("yyyy-MM-dd"), assetAllocation.ReturnDate?.ToString("yyyy-MM-dd") ?? "N/A");
                Console.WriteLine("-------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Asset allocation not found.");
            }
        }

        // Method to view all asset allocations , call the GetAllAssetAllocations method of the AssetAllocationService class and display
        // this method receives the AssetAllocationService instance as a parameter
        static void ViewAllAssetAllocations(AssetAllocationService assetAllocationService)
        {
            var assetAllocations = assetAllocationService.GetAllAssetAllocations();
            if (assetAllocations.Any())
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("| {0,-15} | {1,-10} | {2,-10} | {3,-15} | {4,-15} |",
                    "Allocation ID", "Asset ID", "Employee ID", "Allocation Date", "Return Date");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");

                foreach (var assetAllocation in assetAllocations)
                {
                    Console.WriteLine("| {0,-15} | {1,-10} | {2,-10} | {3,-15} | {4,-15} |",
                        assetAllocation.AllocationId, assetAllocation.AssetId, assetAllocation.EmployeeId, assetAllocation.AllocationDate.ToString("yyyy-MM-dd"), assetAllocation.ReturnDate?.ToString("yyyy-MM-dd") ?? "N/A");
                }

                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No asset allocations found.");
            }
        }

        // static void ReserveAsset(AssetAllocationService assetAllocationService)
        // {
        //     Console.WriteLine("---------------------------------------------");
        //     Console.WriteLine("---------------------------------------------");
        //     Console.WriteLine("----------RESERVE ASSET---------");
        //     Console.Write("Enter Asset ID: ");
        //     var assetId = int.Parse(Console.ReadLine());
        //     Console.Write("Enter Employee ID: ");
        //     var employeeId = int.Parse(Console.ReadLine());
        //     Console.Write("Enter Reservation Date (yyyy-mm-dd): ");
        //     var reservationDate = Console.ReadLine();
        //     Console.Write("Enter Start Date (yyyy-mm-dd): ");
        //     var startDate = Console.ReadLine();
        //     Console.Write("Enter End Date (yyyy-mm-dd): ");
        //     var endDate = Console.ReadLine();

        //     if (assetAllocationService.ReserveAsset(assetId, employeeId, reservationDate, startDate, endDate))
        //     {
        //         Console.WriteLine("Asset reserved successfully.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Failed to reserve asset.");
        //     }
        // }

        // static void WithdrawReservation(AssetAllocationService assetAllocationService)
        // {
        //     Console.WriteLine("---------------------------------------------");
        //     Console.WriteLine("---------------------------------------------");
        //     Console.WriteLine("----------WITHDRAW RESERVATION---------");
        //     Console.Write("Enter Reservation ID: ");
        //     var reservationId = int.Parse(Console.ReadLine());

        //     if (assetAllocationService.WithdrawReservation(reservationId))
        //     {
        //         Console.WriteLine("Reservation withdrawn successfully.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Failed to withdraw reservation.");
        //     }
        // }
    }
}