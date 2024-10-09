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
                Console.WriteLine("Asset Management");
                Console.WriteLine("1. Add Asset");
                Console.WriteLine("2. Update Asset");
                Console.WriteLine("3. Delete Asset");
                Console.WriteLine("4. View Asset by ID");
                Console.WriteLine("5. View All Assets");
                Console.WriteLine("6. Back to Main Menu");
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

            if (assetService.AddAsset(asset))
            {
                Console.WriteLine("Asset added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add asset.");
            }
        }

        static void UpdateAsset(AssetService assetService)
        {
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

            if (assetService.UpdateAsset(asset))
            {
                Console.WriteLine("Asset updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update asset.");
            }
        }

        static void DeleteAsset(AssetService assetService)
        {
            Console.Write("Enter Asset ID: ");
            var assetId = int.Parse(Console.ReadLine());

            if (assetService.DeleteAsset(assetId))
            {
                Console.WriteLine("Asset deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete asset.");
            }
        }

        static void ViewAssetById(AssetService assetService)
        {
            Console.Write("Enter Asset ID: ");
            var assetId = int.Parse(Console.ReadLine());

            var asset = assetService.GetAssetById(assetId);
            if (asset != null)
            {
                Console.WriteLine($"ID: {asset.AssetId}, Name: {asset.Name}, Type: {asset.Type}, Serial Number: {asset.SerialNumber}, Purchase Date: {asset.PurchaseDate}, Location: {asset.Location}, Status: {asset.Status}, Owner ID: {asset.OwnerId}");
            }
            else
            {
                Console.WriteLine("Asset not found.");
            }
        }

        static void ViewAllAssets(AssetService assetService)
        {
            var assets = assetService.GetAllAssets();
            foreach (var asset in assets)
            {
                Console.WriteLine($"ID: {asset.AssetId}, Name: {asset.Name}, Type: {asset.Type}, Serial Number: {asset.SerialNumber}, Purchase Date: {asset.PurchaseDate}, Location: {asset.Location}, Status: {asset.Status}, Owner ID: {asset.OwnerId}");
            }
        }
    }
}