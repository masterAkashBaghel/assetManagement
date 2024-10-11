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
                        PerformMaintenance(maintenanceRecordService);
                        break;
                    case "7":
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
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Add Maintenance Record");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Enter maintennace record  ID: ");
            maintenanceRecord.MaintenanceId = int.Parse(Console.ReadLine());
            Console.Write("Enter Asset ID: ");
            maintenanceRecord.AssetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Maintenance Date (yyyy-mm-dd): ");
            maintenanceRecord.MaintenanceDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Description: ");
            maintenanceRecord.Description = Console.ReadLine();
            Console.Write("Enter Cost: ");
            maintenanceRecord.Cost = double.Parse(Console.ReadLine());

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

        static void UpdateMaintenanceRecord(MaintenanceRecordService maintenanceRecordService)
        {
            var maintenanceRecord = new MaintenanceRecord();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Update Maintenance Record");
            Console.WriteLine("---------------------------------------------");
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

        static void DeleteMaintenanceRecord(MaintenanceRecordService maintenanceRecordService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Delete Maintenance Record");
            Console.WriteLine("---------------------------------------------");
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
            Console.WriteLine("---------------------------------------------");
        }
        static void ViewMaintenanceRecordById(MaintenanceRecordService maintenanceRecordService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("View Maintenance Record by ID");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Enter Maintenance Record ID: ");
            var maintenanceRecordId = int.Parse(Console.ReadLine());

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

        static void ViewAllMaintenanceRecords(MaintenanceRecordService maintenanceRecordService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("View All Maintenance Records");
            Console.WriteLine("---------------------------------------------");

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

        static void PerformMaintenance(MaintenanceRecordService maintenanceRecordService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Perform Maintenance");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Enter Asset ID: ");
            var assetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Maintenance Date (yyyy-mm-dd): ");
            var maintenanceDate = Console.ReadLine();
            Console.Write("Enter Description: ");
            var description = Console.ReadLine();
            Console.Write("Enter Cost: ");
            var cost = double.Parse(Console.ReadLine());

            if (maintenanceRecordService.PerformMaintenance(assetId, maintenanceDate, description, cost))
            {
                Console.WriteLine("Maintenance recorded successfully.");
            }
            else
            {
                Console.WriteLine("Failed to record maintenance.");
            }
            Console.WriteLine("---------------------------------------------");
        }
    }
}