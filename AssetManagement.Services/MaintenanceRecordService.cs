using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;
using System;
using System.Collections.Generic;

namespace AssetManagement.Services
{
    // Service class for the MaintenanceRecordRepository class that implements the IMaintenanceRecordRepository interface   
    // Contains methods that call the corresponding methods in the MaintenanceRecordRepository class

    public class MaintenanceRecordService
    {
        // Private field of type MaintenanceRecordRepository that stores the MaintenanceRecordRepository object
        private readonly MaintenanceRecordRepository _maintenanceRecordRepository;

        // Constructor that takes a MaintenanceRecordRepository object as a parameter and assigns it to the private field
        public MaintenanceRecordService(MaintenanceRecordRepository maintenanceRecordRepository)
        {
            // Assign the parameter to the private field
            _maintenanceRecordRepository = maintenanceRecordRepository;
        }

        // Method to add a maintenance record to the repository

        public bool AddMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            try
            {
                // Call the AddMaintenanceRecord method of the MaintenanceRecordRepository class and return the result
                return _maintenanceRecordRepository.AddMaintenanceRecord(maintenanceRecord);
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to add maintenance record.", ex);
            }
        }
        // Method to update a maintenance record in the repository
        public bool UpdateMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            try
            {
                // Check if the maintenance record exists in the repository by calling the GetMaintenanceRecordById method of the MaintenanceRecordRepository class
                return _maintenanceRecordRepository.UpdateMaintenanceRecord(maintenanceRecord);
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to update maintenance record.", ex);
            }
        }

        // Method to delete a maintenance record from the repository
        public bool DeleteMaintenanceRecord(int maintenanceId)
        {
            try
            {
                // Check if the maintenance record exists in the repository by calling the GetMaintenanceRecordById method of the MaintenanceRecordRepository class
                return _maintenanceRecordRepository.DeleteMaintenanceRecord(maintenanceId);
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to delete maintenance record.", ex);
            }
        }

        // Method to retrieve a maintenance record by its ID
        public MaintenanceRecord GetMaintenanceRecordById(int maintenanceId)
        {
            try
            {
                // Check if the maintenance record exists in the repository by calling the GetMaintenanceRecordById method of the MaintenanceRecordRepository class and return the result
                return _maintenanceRecordRepository.GetMaintenanceRecordById(maintenanceId);
            }
            catch (Exception ex)
            {
                // Throw a MaintenanceException if the maintenance record is not found
                throw new MaintenanceException("Failed to retrieve maintenance record by ID.", ex);
            }
        }

        // Method to retrieve all maintenance records from the repository
        public IEnumerable<MaintenanceRecord> GetAllMaintenanceRecords()
        {
            try
            {
                // Call the GetAllMaintenanceRecords method of the MaintenanceRecordRepository class and return the result
                return _maintenanceRecordRepository.GetAllMaintenanceRecords();
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to retrieve all maintenance records.", ex);
            }
        }

        // Method to perform maintenance on an asset
        public bool PerformMaintenance(int maintenanceId, int assetId, string maintenanceDate, string description, double cost)
        {
            try
            {
                // Call the PerformMaintenance method of the MaintenanceRecordRepository class and return the result 
                return _maintenanceRecordRepository.PerformMaintenance(maintenanceId, assetId, maintenanceDate, description, cost);
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to perform maintenance.", ex);
            }
        }
    }
}