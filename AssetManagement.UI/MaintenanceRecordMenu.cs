using System;
using AssetManagement.Services;
using AssetManagement.Entities;
using AssetManagement.Business;
using AssetManagement.Exceptions;

namespace AssetManagement.UI
{
    public static class MaintenanceRecordMenu
    {
        // Method to display the maintenance record management menu
        public static void Show()
        {
            // Initialize the MaintenanceRecordService with an instance of MaintenanceRecordRepository
            var maintenanceRecordService = new MaintenanceRecordService(new MaintenanceRecordRepository());

            // Infinite loop to keep the menu running until the user chooses to exit
            while (true)
            {
                // Display the menu options
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("--------Maintenance Record Management--------");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1. Add Maintenance Record");
                Console.WriteLine("2. Update Maintenance Record");
                Console.WriteLine("3. Delete Maintenance Record");
                Console.WriteLine("4. View Maintenance Record by ID");
                Console.WriteLine("5. View All Maintenance Records");
                Console.WriteLine("6. Perform Maintenance");
                Console.WriteLine("7. Back to Main Menu");
                Console.WriteLine("---------------------------------------------");

                // Prompt the user to select an option
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                // Handle the user's selection
                switch (option)
                {
                    case "1":
                        AddMaintenanceRecord(maintenanceRecordService);
                        break;
                    case "2":
                        UpdateMaintenanceRecord(maintenanceRecordService);
                        break;
                    case "3":
                        DeleteMaintenanceRecord(maintenanceRecordService);
                        break;
                    case "4":
                        ViewMaintenanceRecordById(maintenanceRecordService);
                        break;
                    case "5":
                        ViewAllMaintenanceRecords(maintenanceRecordService);
                        break;
                    case "6":
                        PerformMaintenance(maintenanceRecordService);
                        break;
                    case "7":
                        return; // Exit the menu
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Method to add a new maintenance record
        static void AddMaintenanceRecord(MaintenanceRecordService maintenanceRecordService)
        {
            var maintenanceRecord = new MaintenanceRecord();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Add Maintenance Record");
            Console.WriteLine("---------------------------------------------");

            // Prompt the user to enter maintenance record details
            Console.Write("Enter Maintenance Record ID: ");
            maintenanceRecord.MaintenanceId = int.Parse(Console.ReadLine());
            Console.Write("Enter Asset ID: ");
            maintenanceRecord.AssetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Maintenance Date (yyyy-mm-dd): ");
            maintenanceRecord.MaintenanceDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Description: ");
            maintenanceRecord.Description = Console.ReadLine();
            Console.Write("Enter Cost: ");
            maintenanceRecord.Cost = double.Parse(Console.ReadLine());

            // Attempt to add the maintenance record using the MaintenanceRecordService
            if (maintenanceRecordService.AddMaintenanceRecord(maintenanceRecord))
            {
                Console.WriteLine("Maintenance record added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add maintenance record.");
            }
            Console.WriteLine("---------------------------------------------");
        }

        // Method to update an existing maintenance record
        static void UpdateMaintenanceRecord(MaintenanceRecordService maintenanceRecordService)
        {
            var maintenanceRecord = new MaintenanceRecord();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Update Maintenance Record");
            Console.WriteLine("---------------------------------------------");

            // Prompt the user to enter updated maintenance record details
            Console.Write("Enter Maintenance Record ID: ");
            maintenanceRecord.MaintenanceId = int.Parse(Console.ReadLine());
            Console.Write("Enter Asset ID: ");
            maintenanceRecord.AssetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Maintenance Date (yyyy-mm-dd): ");
            maintenanceRecord.MaintenanceDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Description: ");
            maintenanceRecord.Description = Console.ReadLine();
            Console.Write("Enter Cost: ");
            maintenanceRecord.Cost = double.Parse(Console.ReadLine());

            // Attempt to update the maintenance record using the MaintenanceRecordService
            if (maintenanceRecordService.UpdateMaintenanceRecord(maintenanceRecord))
            {
                Console.WriteLine("Maintenance record updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update maintenance record.");
            }
            Console.WriteLine("---------------------------------------------");
        }

        // Method to delete an existing maintenance record
        static void DeleteMaintenanceRecord(MaintenanceRecordService maintenanceRecordService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Delete Maintenance Record");
            Console.WriteLine("---------------------------------------------");

            // Prompt the user to enter the maintenance record ID to delete
            Console.Write("Enter Maintenance Record ID: ");
            var maintenanceRecordId = int.Parse(Console.ReadLine());

            // Attempt to delete the maintenance record using the MaintenanceRecordService
            if (maintenanceRecordService.DeleteMaintenanceRecord(maintenanceRecordId))
            {
                Console.WriteLine("Maintenance record deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete maintenance record.");
            }
            Console.WriteLine("---------------------------------------------");
        }

        // Method to view a maintenance record by its ID
        static void ViewMaintenanceRecordById(MaintenanceRecordService maintenanceRecordService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("View Maintenance Record by ID");
            Console.WriteLine("---------------------------------------------");

            // Prompt the user to enter the maintenance record ID to view
            Console.Write("Enter Maintenance Record ID: ");
            var maintenanceRecordId = int.Parse(Console.ReadLine());

            // Retrieve the maintenance record using the MaintenanceRecordService
            var maintenanceRecord = maintenanceRecordService.GetMaintenanceRecordById(maintenanceRecordId);
            if (maintenanceRecord != null)
            {
                // Print table header
                Console.WriteLine("{0,-5} | {1,-8} | {2,-20} | {3,-30} | {4,-10}", "ID", "Asset ID", "Maintenance Date", "Description", "Cost");
                Console.WriteLine(new string('-', 80));

                // Print table row
                Console.WriteLine("{0,-5} | {1,-8} | {2,-20} | {3,-30} | {4,-10:F2}",
                    maintenanceRecord.MaintenanceId,
                    maintenanceRecord.AssetId,
                    maintenanceRecord.MaintenanceDate.ToString("yyyy-MM-dd"),
                    maintenanceRecord.Description,
                    maintenanceRecord.Cost);
            }
            else
            {
                Console.WriteLine("Maintenance record not found.");
            }
            Console.WriteLine("---------------------------------------------");
        }

        // Method to view all maintenance records
        static void ViewAllMaintenanceRecords(MaintenanceRecordService maintenanceRecordService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("View All Maintenance Records");
            Console.WriteLine("---------------------------------------------");

            // Retrieve all maintenance records using the MaintenanceRecordService
            var maintenanceRecords = maintenanceRecordService.GetAllMaintenanceRecords();

            // Print table header
            Console.WriteLine("{0,-5} | {1,-8} | {2,-20} | {3,-30} | {4,-10}", "ID", "Asset ID", "Maintenance Date", "Description", "Cost");
            Console.WriteLine(new string('-', 80));

            // Print table rows
            foreach (var maintenanceRecord in maintenanceRecords)
            {
                Console.WriteLine("{0,-5} | {1,-8} | {2,-20} | {3,-30} | {4,-10:F2}",
                    maintenanceRecord.MaintenanceId,
                    maintenanceRecord.AssetId,
                    maintenanceRecord.MaintenanceDate.ToString("yyyy-MM-dd"),
                    maintenanceRecord.Description,
                    maintenanceRecord.Cost);
            }

            Console.WriteLine("---------------------------------------------");
        }

        // Method to perform maintenance on an asset
        static void PerformMaintenance(MaintenanceRecordService maintenanceRecordService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Perform Maintenance");
            Console.WriteLine("---------------------------------------------");

            // Prompt the user to enter maintenance details
            Console.Write("Enter Maintenance ID: ");
            var maintenanceIdInput = Console.ReadLine();
            if (string.IsNullOrEmpty(maintenanceIdInput) || !int.TryParse(maintenanceIdInput, out var maintenanceId))
            {
                Console.WriteLine("Invalid Maintenance ID. Please try again.");
                return;
            }

            Console.Write("Enter Asset ID: ");
            var assetIdInput = Console.ReadLine();
            if (string.IsNullOrEmpty(assetIdInput) || !int.TryParse(assetIdInput, out var assetId))
            {
                Console.WriteLine("Invalid Asset ID. Please try again.");
                return;
            }

            Console.Write("Enter Maintenance Date (yyyy-mm-dd): ");
            var maintenanceDate = Console.ReadLine();
            if (string.IsNullOrEmpty(maintenanceDate))
            {
                Console.WriteLine("Invalid Maintenance Date. Please try again.");
                return;
            }

            Console.Write("Enter Description: ");
            var description = Console.ReadLine();
            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Invalid Description. Please try again.");
                return;
            }

            Console.Write("Enter Cost: ");
            var costInput = Console.ReadLine();
            if (string.IsNullOrEmpty(costInput) || !double.TryParse(costInput, out var cost))
            {
                Console.WriteLine("Invalid Cost. Please try again.");
                return;
            }

            try
            {
                // Attempt to perform maintenance using the MaintenanceRecordService
                if (maintenanceRecordService.PerformMaintenance(maintenanceId, assetId, maintenanceDate, description, cost))
                {
                    Console.WriteLine("Maintenance recorded successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to record maintenance.");
                }
            }
            catch (MaintenanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("---------------------------------------------");
        }
    }
}