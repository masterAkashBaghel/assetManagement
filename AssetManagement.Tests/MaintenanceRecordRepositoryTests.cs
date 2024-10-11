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

        [SetUp]
        public void Setup()
        {
            _repository = new MaintenanceRecordRepository();
        }

        [Test]
        public void AddMaintenanceRecord_ShouldReturnTrue_WhenRecordIsAdded()
        {
            var maintenanceRecord = new MaintenanceRecord
            {
                AssetId = 1,
                MaintenanceDate = DateTime.Now,
                Description = "Test Maintenance",
                Cost = 100.0
            };

            var result = _repository.AddMaintenanceRecord(maintenanceRecord);

            Assert.IsTrue(result);
        }

        [Test]
        public void AddMaintenanceRecord_ShouldReturnFalse_WhenRecordAdditionFails()
        {
            var maintenanceRecord = new MaintenanceRecord
            {
                AssetId = -1, // Invalid asset ID to simulate failure
                MaintenanceDate = DateTime.Now,
                Description = "Test Maintenance",
                Cost = 100.0
            };

            var result = _repository.AddMaintenanceRecord(maintenanceRecord);

            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateMaintenanceRecord_ShouldReturnTrue_WhenRecordIsUpdated()
        {
            var maintenanceRecord = new MaintenanceRecord
            {
                MaintenanceId = 1,
                AssetId = 1,
                MaintenanceDate = DateTime.Now,
                Description = "Updated Maintenance",
                Cost = 150.0
            };

            var result = _repository.UpdateMaintenanceRecord(maintenanceRecord);

            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateMaintenanceRecord_ShouldReturnFalse_WhenRecordUpdateFails()
        {
            var maintenanceRecord = new MaintenanceRecord
            {
                MaintenanceId = -1, // Invalid maintenance ID to simulate failure
                AssetId = 1,
                MaintenanceDate = DateTime.Now,
                Description = "Updated Maintenance",
                Cost = 150.0
            };

            var result = _repository.UpdateMaintenanceRecord(maintenanceRecord);

            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteMaintenanceRecord_ShouldReturnTrue_WhenRecordIsDeleted()
        {
            var result = _repository.DeleteMaintenanceRecord(1);

            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteMaintenanceRecord_ShouldReturnFalse_WhenRecordDeletionFails()
        {
            var result = _repository.DeleteMaintenanceRecord(-1); // Invalid maintenance ID to simulate failure

            Assert.IsFalse(result);
        }

        [Test]
        public void GetMaintenanceRecordById_ShouldReturnRecord_WhenRecordExists()
        {
            var maintenanceRecord = _repository.GetMaintenanceRecordById(1);

            Assert.IsNotNull(maintenanceRecord);
        }

        [Test]
        public void GetMaintenanceRecordById_ShouldReturnNull_WhenRecordDoesNotExist()
        {
            var maintenanceRecord = _repository.GetMaintenanceRecordById(-1); // Invalid maintenance ID to simulate not found

            Assert.IsNull(maintenanceRecord);
        }

        [Test]
        public void GetAllMaintenanceRecords_ShouldReturnListOfRecords()
        {
            var maintenanceRecords = _repository.GetAllMaintenanceRecords();

            Assert.IsNotNull(maintenanceRecords);
            Assert.IsNotEmpty(maintenanceRecords);
        }

        [Test]
        public void PerformMaintenance_ShouldReturnTrue_WhenMaintenanceIsPerformed()
        {
            var result = _repository.PerformMaintenance(1, DateTime.Now.ToString("yyyy-MM-dd"), "Test Maintenance", 100.0);

            Assert.IsTrue(result);
        }

        [Test]
        public void PerformMaintenance_ShouldReturnFalse_WhenMaintenanceFails()
        {
            var result = _repository.PerformMaintenance(-1, DateTime.Now.ToString("yyyy-MM-dd"), "Test Maintenance", 100.0); // Invalid asset ID to simulate failure

            Assert.IsFalse(result);
        }
    }
}