using System;
using AssetManagement.Services;
using AssetManagement.Entities;
using AssetManagement.Business;

namespace AssetManagement.UI
{
    public static class AssetMenu
    {
        public static void Show()
        {
            var assetService = new AssetService(new AssetRepository());

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

        static void AddAsset(AssetService assetService)
        {
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

            if (assetService.AddAsset(asset))
            {
                Console.WriteLine("$Asset {asset.Name} added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add asset.");
            }
        }

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

            if (assetService.UpdateAsset(asset))
            {
                Console.WriteLine($"Asset {asset.Name} updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update asset.");
            }
        }

        static void DeleteAsset(AssetService assetService)
        {

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("----------DELETE ASSET---------");

            Console.Write("Enter Asset ID: ");
            var assetId = int.Parse(Console.ReadLine());

            if (assetService.DeleteAsset(assetId))
            {
                Console.WriteLine("$Asset {assetId} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete asset.");
            }
        }

        static void ViewAssetById(AssetService assetService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("----------VIEW ASSET BY ID---------");
            System.Console.WriteLine();
            Console.Write("Enter Asset ID: ");
            var assetId = int.Parse(Console.ReadLine());

            System.Console.WriteLine();

            var asset = assetService.GetAssetById(assetId);
            if (asset != null)
            {
                Console.WriteLine("-------------------------------------------------------------");
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

        static void ViewAllAssets(AssetService assetService)
        {
            var assets = assetService.GetAllAssets();
            if (assets.Any())
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,-15} | {4,-15} | {5,-15} | {6,-10} | {7,-10} |",
                    "ID", "Name", "Type", "Serial Number", "Purchase Date", "Location", "Status", "Owner ID");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");

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