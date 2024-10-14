using NUnit.Framework;
using AssetManagement.Entities;
using AssetManagement.Services;
using AssetManagement.Exceptions;
using AssetManagement.Business;
using System.Collections.Generic;

namespace AssetManagement.Tests
{
    [TestFixture]
    public class AssetServiceTests
    {
        private AssetService _assetService;

        // Setup method to initialize the test environment
        [SetUp]
        public void Setup()
        {
            // Create an instance of AssetRepository
            var assetRepository = new AssetRepository();
            // Initialize the AssetService with the AssetRepository
            _assetService = new AssetService(assetRepository);
        }

        // Test to verify that GetAssetById throws AssetNotFoundException for a non-existent asset
        [Test]
        public void GetAssetById_ShouldThrowAssetNotFoundException()
        {
            // Assert that calling GetAssetById with a non-existent ID throws AssetNotFoundException
            Assert.Throws<AssetNotFoundException>(() => _assetService.GetAssetById(999));
        }

        // Test to verify that UpdateAsset throws AssetNotFoundException for a non-existent asset
        [Test]
        public void UpdateAsset_ShouldThrowAssetNotFoundException()
        {
            // Create a new asset with a non-existent ID
            var asset = new Asset
            {
                AssetId = 999,
                Name = "Asset Not Exists",
                Type = "Type",
                SerialNumber = "SN12345",
                PurchaseDate = DateTime.Now,
                Location = "Location",
                Status = "Status",
                OwnerId = 1
            };
            // Assert that calling UpdateAsset with a non-existent asset throws AssetNotFoundException
            Assert.Throws<AssetNotFoundException>(() => _assetService.UpdateAsset(asset));
        }

        // Test to verify that DeleteAsset throws AssetNotFoundException for a non-existent asset
        [Test]
        public void DeleteAsset_ShouldThrowAssetNotFoundException()
        {
            // Assert that calling DeleteAsset with a non-existent ID throws AssetNotFoundException
            Assert.Throws<AssetNotFoundException>(() => _assetService.DeleteAsset(999));
        }

        // Test to verify that AddAsset successfully adds a new asset
        [Test]
        public void AddAsset_ShouldAddAsset()
        {
            // Create a new asset
            var asset = new Asset
            {
                AssetId = 1,
                Name = "Asset 1",
                Type = "Type",
                SerialNumber = "SN12345",
                PurchaseDate = DateTime.Now,
                Location = "Location",
                Status = "Status",
                OwnerId = 1
            };

            // Add the asset and store the result
            var result = _assetService.AddAsset(asset);

            // Assert that the asset was successfully added
            Assert.IsTrue(result);
        }

        // Test to verify that AddAsset does not add a duplicate asset
        [Test]
        public void AddAsset_ShouldNotAddDuplicateAsset()
        {
            // Create a new asset
            var asset = new Asset
            {
                AssetId = 1,
                Name = "Asset 1",
                Type = "Type",
                SerialNumber = "SN12345",
                PurchaseDate = DateTime.Now,
                Location = "Bengal",
                Status = "Status",
                OwnerId = 1
            };

            // Add the asset for the first time
            _assetService.AddAsset(asset);
            // Try to add the same asset again and store the result
            var result = _assetService.AddAsset(asset);

            // Assert that the duplicate asset was not added
            Assert.IsFalse(result);
        }
    }
}