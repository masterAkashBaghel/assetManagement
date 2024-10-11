using NUnit.Framework;
using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;
using System;

namespace AssetManagement.Tests
{
    [TestFixture]
    public class AssetAllocationRepositoryTests
    {
        private AssetAllocationRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new AssetAllocationRepository();
        }

        [Test]
        public void AllocateAsset_ShouldReturnTrue_WhenAllocationIsSuccessful()
        {
            var allocation = new AssetAllocation
            {
                AssetId = 1,
                EmployeeId = 1,
                AllocationDate = DateTime.Now
            };

            var result = _repository.AllocateAsset(allocation);

            Assert.IsTrue(result);
        }

        [Test]
        public void AllocateAsset_ShouldReturnFalse_WhenAllocationFails()
        {
            var allocation = new AssetAllocation
            {
                AssetId = -1, // Invalid asset ID to simulate failure
                EmployeeId = 1,
                AllocationDate = DateTime.Now
            };

            var result = _repository.AllocateAsset(allocation);

            Assert.IsFalse(result);
        }

        [Test]
        public void DeallocateAsset_ShouldReturnTrue_WhenDeallocationIsSuccessful()
        {
            var result = _repository.DeallocateAsset(1, DateTime.Now);

            Assert.IsTrue(result);
        }

        [Test]
        public void DeallocateAsset_ShouldReturnFalse_WhenDeallocationFails()
        {
            var result = _repository.DeallocateAsset(-1, DateTime.Now); // Invalid allocation ID to simulate failure

            Assert.IsFalse(result);
        }

        [Test]
        public void GetAssetAllocationById_ShouldReturnAllocation_WhenAllocationExists()
        {
            var allocation = _repository.GetAssetAllocationById(1);

            Assert.IsNotNull(allocation);
        }

        [Test]
        public void GetAssetAllocationById_ShouldReturnNull_WhenAllocationDoesNotExist()
        {
            var allocation = _repository.GetAssetAllocationById(-1); // Invalid allocation ID to simulate not found

            Assert.IsNull(allocation);
        }

        [Test]
        public void GetAllAssetAllocations_ShouldReturnListOfAllocations()
        {
            var allocations = _repository.GetAllAssetAllocations();

            Assert.IsNotNull(allocations);
            Assert.IsNotEmpty(allocations);
        }
    }
}