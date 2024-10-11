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

        [SetUp]
        public void Setup()
        {
            var assetRepository = new AssetRepository();
            _assetService = new AssetService(assetRepository);
        }

        [Test]
        public void GetAssetById_ShouldThrowAssetNotFoundException()
        {
            Assert.Throws<AssetNotFoundException>(() => _assetService.GetAssetById(999));
        }

        [Test]
        public void UpdateAsset_ShouldThrowAssetNotFoundException()
        {
            var asset = new Asset
            {
                AssetId = 999,
                Name = "Nonexistent Asset",
                Type = "Type",
                SerialNumber = "SN12345",
                PurchaseDate = DateTime.Now,
                Location = "Location",
                Status = "Status",
                OwnerId = 1
            };
            Assert.Throws<AssetNotFoundException>(() => _assetService.UpdateAsset(asset));
        }

        [Test]
        public void DeleteAsset_ShouldThrowAssetNotFoundException()
        {
            Assert.Throws<AssetNotFoundException>(() => _assetService.DeleteAsset(999));
        }

        [Test]
        public void AddAsset_ShouldAddAsset()
        {
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

            var result = _assetService.AddAsset(asset);

            Assert.IsTrue(result);

        }

        [Test]
        public void AddAsset_ShouldNotAddDuplicateAsset()
        {
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

            _assetService.AddAsset(asset);
            var result = _assetService.AddAsset(asset);

            Assert.IsFalse(result);

        }
    }
}