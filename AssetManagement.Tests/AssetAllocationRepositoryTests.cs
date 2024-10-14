using NUnit.Framework;
using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;
using System;

namespace AssetManagement.Tests
{
    // Test class for the AssetAllocationRepository class
    // Contains unit tests for the methods of the AssetAllocationRepository class
    [TestFixture]
    //
    public class AssetAllocationRepositoryTests
    {
        // Private field of type AssetAllocationRepository that stores the AssetAllocationRepository object
        private AssetAllocationRepository _repository;

        // Setup method that runs before each test method
        [SetUp]

        // Instantiate the AssetAllocationRepository object
        public void Setup()
        {
            // Assign the parameter to the private field
            _repository = new AssetAllocationRepository();
        }

        [Test]
        // Test method for the AllocateAsset method
        public void AllocateAsset_ShouldReturnTrue_WhenAllocationIsSuccessful()
        {
            // Create a new AssetAllocation object
            var allocation = new AssetAllocation
            {
                AssetId = 1,
                EmployeeId = 1,
                AllocationDate = DateTime.Now
            };
            // Call the AllocateAsset method of the AssetAllocationRepository class and store the result in a variable
            var result = _repository.AllocateAsset(allocation);
            // Assert that the result is true (successful allocation)
            Assert.IsTrue(result);
        }

        [Test]
        // Test method for the AllocateAsset method
        public void AllocateAsset_ShouldReturnFalse_WhenAllocationFails()
        {
            // Create a new AssetAllocation object with an invalid asset ID to simulate failure
            var allocation = new AssetAllocation
            {
                AssetId = -1, // Invalid asset ID to simulate failure
                EmployeeId = 1,
                AllocationDate = DateTime.Now
            };
            // Call the AllocateAsset method of the AssetAllocationRepository class and store the result in a variable
            var result = _repository.AllocateAsset(allocation);
            // Assert that the result is false (failed allocation)
            Assert.IsFalse(result);
        }

        [Test]
        // Test method for the DeallocateAsset method
        public void DeallocateAsset_ShouldReturnTrue_WhenDeallocationIsSuccessful()
        {
            // Call the DeallocateAsset method of the AssetAllocationRepository class and store the result in a variable
            var result = _repository.DeallocateAsset(1, DateTime.Now);
            // Assert that the result is true (successful deallocation)
            Assert.IsTrue(result);
        }

        [Test]
        // Test method for the DeallocateAsset method with an invalid allocation ID
        public void DeallocateAsset_ShouldReturnFalse_WhenDeallocationFails()
        {
            // Call the DeallocateAsset method of the AssetAllocationRepository class with an invalid allocation ID and store the result in a variable
            var result = _repository.DeallocateAsset(-1, DateTime.Now); // Invalid allocation ID to simulate failure
            // Assert that the result is false (failed deallocation)
            Assert.IsFalse(result);
        }

        [Test]
        // Test method for the GetAssetAllocationById method
        public void GetAssetAllocationById_ShouldReturnAllocation_WhenAllocationExists()
        {
            // Call the GetAssetAllocationById method of the AssetAllocationRepository class and store the result in a variable
            var allocation = _repository.GetAssetAllocationById(1);
            // Assert that the allocation is not null (allocation exists)
            Assert.IsNotNull(allocation);
        }

        [Test]
        // Test method for the GetAssetAllocationById method with an invalid allocation ID
        public void GetAssetAllocationById_ShouldReturnNull_WhenAllocationDoesNotExist()
        {
            // Call the GetAssetAllocationById method of the AssetAllocationRepository class with an invalid allocation ID and store the result in a variable
            var allocation = _repository.GetAssetAllocationById(-1); // Invalid allocation ID to simulate not found
            // Assert that the allocation is null (allocation does not exist)
            Assert.IsNull(allocation);
        }

        [Test]
        // Test method for the GetAllAssetAllocations method
        public void GetAllAssetAllocations_ShouldReturnListOfAllocations()
        {
            // Call the GetAllAssetAllocations method of the AssetAllocationRepository class and store the result in a variable
            var allocations = _repository.GetAllAssetAllocations();
            // Assert that the allocations list is not null and not empty
            Assert.IsNotNull(allocations);
            Assert.IsNotEmpty(allocations);
        }
    }
}