using NUnit.Framework;
using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;
using System;

namespace AssetManagement.Tests
{
    [TestFixture]
    public class MaintenanceRecordRepositoryTests
    {
        private MaintenanceRecordRepository _repository;

        // Setup method to initialize the test environment
        [SetUp]
        public void Setup()
        {
            // Initialize the MaintenanceRecordRepository
            _repository = new MaintenanceRecordRepository();
        }

        // Test to verify that AddMaintenanceRecord returns true when a record is successfully added
        [Test]
        public void AddMaintenanceRecord_ShouldReturnTrue_WhenRecordIsAdded()
        {
            // Arrange: Create a new maintenance record
            var maintenanceRecord = new MaintenanceRecord
            {
                AssetId = 1,
                MaintenanceDate = DateTime.Now,
                Description = "Test Maintenance",
                Cost = 100.0
            };

            // Act: Add the maintenance record
            var result = _repository.AddMaintenanceRecord(maintenanceRecord);

            // Assert: Verify that the record was successfully added
            Assert.IsTrue(result);
        }

        // Test to verify that AddMaintenanceRecord returns false when record addition fails
        [Test]
        public void AddMaintenanceRecord_ShouldReturnFalse_WhenRecordAdditionFails()
        {
            // Arrange: Create a new maintenance record with an invalid asset ID to simulate failure
            var maintenanceRecord = new MaintenanceRecord
            {
                AssetId = -1, // Invalid asset ID
                MaintenanceDate = DateTime.Now,
                Description = "Test Maintenance",
                Cost = 100.0
            };

            // Act: Attempt to add the maintenance record
            var result = _repository.AddMaintenanceRecord(maintenanceRecord);

            // Assert: Verify that the record addition failed
            Assert.IsFalse(result);
        }

        // Test to verify that UpdateMaintenanceRecord returns true when a record is successfully updated
        [Test]
        public void UpdateMaintenanceRecord_ShouldReturnTrue_WhenRecordIsUpdated()
        {
            // Arrange: Create a maintenance record with valid data
            var maintenanceRecord = new MaintenanceRecord
            {
                MaintenanceId = 1,
                AssetId = 1,
                MaintenanceDate = DateTime.Now,
                Description = "Updated Maintenance",
                Cost = 150.0
            };

            // Act: Update the maintenance record
            var result = _repository.UpdateMaintenanceRecord(maintenanceRecord);

            // Assert: Verify that the record was successfully updated
            Assert.IsTrue(result);
        }

        // Test to verify that UpdateMaintenanceRecord returns false when record update fails
        [Test]
        public void UpdateMaintenanceRecord_ShouldReturnFalse_WhenRecordUpdateFails()
        {
            // Arrange: Create a maintenance record with an invalid maintenance ID to simulate failure
            var maintenanceRecord = new MaintenanceRecord
            {
                MaintenanceId = -1, // Invalid maintenance ID
                AssetId = 1,
                MaintenanceDate = DateTime.Now,
                Description = "Updated Maintenance",
                Cost = 150.0
            };

            // Act: Attempt to update the maintenance record
            var result = _repository.UpdateMaintenanceRecord(maintenanceRecord);

            // Assert: Verify that the record update failed
            Assert.IsFalse(result);
        }

        // Test to verify that DeleteMaintenanceRecord returns true when a record is successfully deleted
        [Test]
        public void DeleteMaintenanceRecord_ShouldReturnTrue_WhenRecordIsDeleted()
        {
            // Act: Delete the maintenance record with a valid ID
            var result = _repository.DeleteMaintenanceRecord(1);

            // Assert: Verify that the record was successfully deleted
            Assert.IsTrue(result);
        }

        // Test to verify that DeleteMaintenanceRecord returns false when record deletion fails
        [Test]
        public void DeleteMaintenanceRecord_ShouldReturnFalse_WhenRecordDeletionFails()
        {
            // Act: Attempt to delete the maintenance record with an invalid ID to simulate failure
            var result = _repository.DeleteMaintenanceRecord(-1); // Invalid maintenance ID

            // Assert: Verify that the record deletion failed
            Assert.IsFalse(result);
        }

        // Test to verify that GetMaintenanceRecordById returns the correct record when it exists
        [Test]
        public void GetMaintenanceRecordById_ShouldReturnRecord_WhenRecordExists()
        {
            // Act: Retrieve the maintenance record by a valid ID
            var maintenanceRecord = _repository.GetMaintenanceRecordById(1);

            // Assert: Verify that the retrieved record is not null
            Assert.IsNotNull(maintenanceRecord);
        }

        // Test to verify that GetMaintenanceRecordById returns null when the record does not exist
        [Test]
        public void GetMaintenanceRecordById_ShouldReturnNull_WhenRecordDoesNotExist()
        {
            // Act: Attempt to retrieve the maintenance record by an invalid ID to simulate not found
            var maintenanceRecord = _repository.GetMaintenanceRecordById(-1); // Invalid maintenance ID

            // Assert: Verify that the retrieved record is null
            Assert.IsNull(maintenanceRecord);
        }

        // Test to verify that GetAllMaintenanceRecords returns a list of records
        [Test]
        public void GetAllMaintenanceRecords_ShouldReturnListOfRecords()
        {
            // Act: Retrieve all maintenance records
            var maintenanceRecords = _repository.GetAllMaintenanceRecords();

            // Assert: Verify that the retrieved list is not null and not empty
            Assert.IsNotNull(maintenanceRecords);
            Assert.IsNotEmpty(maintenanceRecords);
        }

        // Test to verify that PerformMaintenance returns true when maintenance is successfully performed
        [Test]
        public void PerformMaintenance_ShouldReturnTrue_WhenMaintenanceIsPerformed()
        {
            // Act: Perform maintenance with valid data
            var result = _repository.PerformMaintenance(1, DateTime.Now.ToString("yyyy-MM-dd"), "Test Maintenance", 100.0);

            // Assert: Verify that the maintenance was successfully performed
            Assert.IsTrue(result);
        }

        // Test to verify that PerformMaintenance returns false when maintenance fails
        [Test]
        public void PerformMaintenance_ShouldReturnFalse_WhenMaintenanceFails()
        {
            // Act: Attempt to perform maintenance with an invalid asset ID to simulate failure
            var result = _repository.PerformMaintenance(-1, DateTime.Now.ToString("yyyy-MM-dd"), "Test Maintenance", 100.0); // Invalid asset ID

            // Assert: Verify that the maintenance failed
            Assert.IsFalse(result);
        }
    }
}