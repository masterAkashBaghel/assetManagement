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
            // Initialize the MaintenanceRecordRepository instance before each test
            _repository = new MaintenanceRecordRepository();
        }

        [Test]
        public void PerformMaintenance_ShouldAddMaintenanceRecord()
        {
            // Arrange: Set up the parameters for the maintenance record
            int maintenanceId = 1;
            int assetId = 1;
            string maintenanceDate = "2023-10-01";
            string description = "Routine check";
            double cost = 100.0;

            // Act: Call the PerformMaintenance method with the parameters
            bool result = _repository.PerformMaintenance(maintenanceId, assetId, maintenanceDate, description, cost);

            // Assert: Verify that the maintenance record was added successfully
            Assert.IsTrue(result);
        }

        [Test]
        public void PerformMaintenance_ShouldThrowExceptionForDuplicateId()
        {
            // Arrange: Set up the parameters for the maintenance record
            int maintenanceId = 1;
            int assetId = 1;
            string maintenanceDate = "2023-10-01";
            string description = "Routine check";
            double cost = 100.0;

            // Act: Call the PerformMaintenance method with the parameters
            _repository.PerformMaintenance(maintenanceId, assetId, maintenanceDate, description, cost);

            // Assert: Verify that an exception is thrown when adding a duplicate maintenance record
            Assert.Throws<MaintenanceException>(() =>
                _repository.PerformMaintenance(maintenanceId, assetId, maintenanceDate, description, cost));
        }
    }
}