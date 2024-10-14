using System;

namespace AssetManagement.UI
{
    class AssetManagementApp
    {
        // Main method to start the application, which displays the main menu
        // and allows the user to navigate to different sections of the application
        //This main method calls the different menu methods to display the options available to the user.
        // The user can select an option to manage employees, assets, maintenance records, asset allocations, reservations, or exit the application.
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
                //The user can select an option to manage employees, assets, maintenance records, asset allocations, reservations, or exit the application.
                // Based on the user's selection, the corresponding menu method is called to display the options for that section of the application.
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