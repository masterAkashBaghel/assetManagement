using System;
using AssetManagement.Services;
using AssetManagement.Entities;
using AssetManagement.Business;

namespace AssetManagement.UI
{

    // Class to display the asset management menu and handle user input, such as adding, updating, deleting, and viewing assets
    public static class AssetMenu
    {
        // Method to display the asset management menu and handle user input
        public static void Show()
        {
            // Create an instance of the AssetService class with an AssetRepository object, which is used to interact with the asset data
            //  instance of the AssetRepository class to be used in the service
            var assetService = new AssetService(new AssetRepository());
            // Display the asset management menu options and handle user input
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("---------------------------------------------");

                Console.WriteLine("-----WELCOME TO ASSET MANAGEMENT DASHBOARD------");
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1. Add Asset");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("2. Update Asset");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("3. Delete Asset");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("4. View Asset by ID");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("5. View All Assets");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("6. Back to Main Menu");
                Console.WriteLine("---------------------------------------------");
                Console.Write("Select an option: ");

                var option = Console.ReadLine();
                // Based on the user's selection, the corresponding method is called to perform the selected action
                switch (option)
                {
                    case "1":
                        AddAsset(assetService);
                        break;
                    case "2":
                        UpdateAsset(assetService);
                        break;
                    case "3":
                        DeleteAsset(assetService);
                        break;
                    case "4":
                        ViewAssetById(assetService);
                        break;
                    case "5":
                        ViewAllAssets(assetService);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }


        // Method to add an asset to the database using the AssetService class and handle user input
        static void AddAsset(AssetService assetService)
        {
            // Create a new asset object and populate its properties with user input data
            var asset = new Asset();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("----------ADD ASSET DETAILS---------");
            Console.Write("Enter Asset ID: ");
            asset.AssetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            asset.Name = Console.ReadLine();
            Console.Write("Enter Type: ");
            asset.Type = Console.ReadLine();
            Console.Write("Enter Serial Number: ");
            asset.SerialNumber = Console.ReadLine();
            Console.Write("Enter Purchase Date (yyyy-mm-dd): ");
            asset.PurchaseDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Location: ");
            asset.Location = Console.ReadLine();
            Console.Write("Enter Status: ");
            asset.Status = Console.ReadLine();
            Console.Write("Enter Owner ID: ");
            asset.OwnerId = int.Parse(Console.ReadLine());

            Console.WriteLine();
            // Call the AddAsset method of the AssetService class to add the asset to the database by passing the asset object
            if (assetService.AddAsset(asset))
            {
                Console.WriteLine("$Asset {asset.Name} added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add asset.");
            }
        }

        // Method to update an asset in the database using the AssetService class and handle user input
        //This method retrieves the asset details from the user and calls the UpdateAsset method of the AssetService class to update the asset in the database.

        static void UpdateAsset(AssetService assetService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("----------UPDATE ASSET DETAILS---------");
            var asset = new Asset();
            Console.Write("Enter Asset ID: ");
            asset.AssetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            asset.Name = Console.ReadLine();
            Console.Write("Enter Type: ");
            asset.Type = Console.ReadLine();
            Console.Write("Enter Serial Number: ");
            asset.SerialNumber = Console.ReadLine();
            Console.Write("Enter Purchase Date (yyyy-mm-dd): ");
            asset.PurchaseDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Location: ");
            asset.Location = Console.ReadLine();
            Console.Write("Enter Status: ");
            asset.Status = Console.ReadLine();
            Console.Write("Enter Owner ID: ");
            asset.OwnerId = int.Parse(Console.ReadLine());

            Console.WriteLine();
            // Call the UpdateAsset method of the AssetService class to update the asset in the database by passing the asset object
            if (assetService.UpdateAsset(asset))
            {
                Console.WriteLine($"Asset {asset.Name} updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update asset.");
            }
        }


        // Method to delete an asset from the database using the AssetService class and handle user input
        static void DeleteAsset(AssetService assetService)
        {

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("----------DELETE ASSET---------");

            Console.Write("Enter Asset ID: ");
            var assetId = int.Parse(Console.ReadLine());
            // Call the DeleteAsset method of the AssetService class to delete the asset from the database by passing the asset ID
            if (assetService.DeleteAsset(assetId))
            {
                Console.WriteLine("$Asset {assetId} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete asset.");
            }
        }

        // Method to view an asset by its ID using the AssetService class and handle user input
        static void ViewAssetById(AssetService assetService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("----------VIEW ASSET BY ID---------");
            Console.WriteLine();
            Console.Write("Enter Asset ID: ");
            var assetId = int.Parse(Console.ReadLine());

            Console.WriteLine();
            // Call the GetAssetById method of the AssetService class to retrieve
            var asset = assetService.GetAssetById(assetId);
            if (asset != null)
            {
                Console.WriteLine("-------------------------------------------------------------");
                // Display the asset details in a formatted table, including the asset ID, name, type, serial number, purchase date, location, status, and owner ID
                Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,-15} | {4,-15} | {5,-10} | {6,-10} | {7,-10} |",
                    "ID", "Name", "Type", "Serial Number", "Purchase Date", "Location", "Status", "Owner ID");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,-15} | {4,-15} | {5,-10} | {6,-10} | {7,-10} |",
                    asset.AssetId, asset.Name, asset.Type, asset.SerialNumber, asset.PurchaseDate.ToString("yyyy-MM-dd"), asset.Location, asset.Status, asset.OwnerId);
                Console.WriteLine("-------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Asset not found.");
            }
        }

        // Method to view all assets using the AssetService class
        static void ViewAllAssets(AssetService assetService)
        {
            // Call the GetAllAssets method of the AssetService class to retrieve all assets from the database
            var assets = assetService.GetAllAssets();
            if (assets.Any())
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
                // Format the asset details in a table, including the asset ID, name, type, serial number, purchase date, location, status, and owner ID
                Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,-15} | {4,-15} | {5,-15} | {6,-10} | {7,-10} |",
                    "ID", "Name", "Type", "Serial Number", "Purchase Date", "Location", "Status", "Owner ID");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
                // Display the asset details in a formatted table, including the asset ID, name, type, serial number, purchase date, location, status, and owner ID
                foreach (var asset in assets)
                {
                    Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,-15} | {4,-15} | {5,-15} | {6,-10} | {7,-10} |",
                        asset.AssetId, asset.Name, asset.Type, asset.SerialNumber, asset.PurchaseDate.ToString("yyyy-MM-dd"), asset.Location, asset.Status, asset.OwnerId);
                }

                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No assets found.");
            }
        }
    }
}