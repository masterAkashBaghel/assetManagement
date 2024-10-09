using System;

namespace AssetManagement.UI
{
    class AssetManagementApp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Asset Management System");
                Console.WriteLine("1. Manage Employees");
                Console.WriteLine("2. Manage Assets");
                Console.WriteLine("3. Manage Maintenance Records");
                Console.WriteLine("4. Manage Asset Allocations");
                Console.WriteLine("5. Manage Reservations");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        EmployeeMenu.Show();
                        break;
                    case "2":
                        AssetMenu.Show();
                        break;
                    case "3":
                        MaintenanceRecordMenu.Show();
                        break;
                    case "4":
                        AssetAllocationMenu.Show();
                        break;
                    case "5":
                        ReservationMenu.Show();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}