using System;

namespace AssetManagement.UI
{
    class AssetManagementApp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("-----WELCOME TO ASSET MANAGEMENT DASHBOARD------");
                Console.WriteLine();
                Console.WriteLine("1. Manage Employees");
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("2. Manage Assets");
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("3. Manage Maintenance Records");
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("4. Manage Asset Allocations");
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("5. Manage Reservations");
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("6. Exit");
                Console.WriteLine("----------------------------------------------------");
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