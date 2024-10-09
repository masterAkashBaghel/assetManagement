using System;
using AssetManagement.Services;
using AssetManagement.Entities;
using AssetManagement.Business;

namespace AssetManagement.UI
{
    public static class MaintenanceRecordMenu
    {
        public static void Show()
        {
            var maintenanceRecordService = new MaintenanceRecordService(new MaintenanceRecordRepository());

            while (true)
            {
                Console.WriteLine("Maintenance Record Management");
                Console.WriteLine("1. Add Maintenance Record");
                Console.WriteLine("2. Update Maintenance Record");
                Console.WriteLine("3. Delete Maintenance Record");
                Console.WriteLine("4. View Maintenance Record by ID");
                Console.WriteLine("5. View All Maintenance Records");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

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
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddMaintenanceRecord(MaintenanceRecordService maintenanceRecordService)
        {
            var maintenanceRecord = new MaintenanceRecord();
            Console.Write("Enter Asset ID: ");
            maintenanceRecord.AssetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Maintenance Date (yyyy-mm-dd): ");
            maintenanceRecord.MaintenanceDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Description: ");
            maintenanceRecord.Description = Console.ReadLine();

            if (maintenanceRecordService.AddMaintenanceRecord(maintenanceRecord))
            {
                Console.WriteLine("Maintenance record added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add maintenance record.");
            }
        }

        static void UpdateMaintenanceRecord(MaintenanceRecordService maintenanceRecordService)
        {
            var maintenanceRecord = new MaintenanceRecord();
            Console.Write("Enter Maintenance Record ID: ");
            maintenanceRecord.MaintenanceRecordId = int.Parse(Console.ReadLine());
            Console.Write("Enter Asset ID: ");
            maintenanceRecord.AssetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Maintenance Date (yyyy-mm-dd): ");
            maintenanceRecord.MaintenanceDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Description: ");
            maintenanceRecord.Description = Console.ReadLine();

            if (maintenanceRecordService.UpdateMaintenanceRecord(maintenanceRecord))
            {
                Console.WriteLine("Maintenance record updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update maintenance record.");
            }
        }

        static void DeleteMaintenanceRecord(MaintenanceRecordService maintenanceRecordService)
        {
            Console.Write("Enter Maintenance Record ID: ");
            var maintenanceRecordId = int.Parse(Console.ReadLine());

            if (maintenanceRecordService.DeleteMaintenanceRecord(maintenanceRecordId))
            {
                Console.WriteLine("Maintenance record deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete maintenance record.");
            }
        }

        static void ViewMaintenanceRecordById(MaintenanceRecordService maintenanceRecordService)
        {
            Console.Write("Enter Maintenance Record ID: ");
            var maintenanceRecordId = int.Parse(Console.ReadLine());

            var maintenanceRecord = maintenanceRecordService.GetMaintenanceRecordById(maintenanceRecordId);
            if (maintenanceRecord != null)
            {
                Console.WriteLine($"ID: {maintenanceRecord.MaintenanceRecordId}, Asset ID: {maintenanceRecord.AssetId}, Maintenance Date: {maintenanceRecord.MaintenanceDate}, Description: {maintenanceRecord.Description}");
            }
            else
            {
                Console.WriteLine("Maintenance record not found.");
            }
        }

        static void ViewAllMaintenanceRecords(MaintenanceRecordService maintenanceRecordService)
        {
            var maintenanceRecords = maintenanceRecordService.GetAllMaintenanceRecords();
            foreach (var maintenanceRecord in maintenanceRecords)
            {
                Console.WriteLine($"ID: {maintenanceRecord.MaintenanceRecordId}, Asset ID: {maintenanceRecord.AssetId}, Maintenance Date: {maintenanceRecord.MaintenanceDate}, Description: {maintenanceRecord.Description}");
            }
        }
    }
}