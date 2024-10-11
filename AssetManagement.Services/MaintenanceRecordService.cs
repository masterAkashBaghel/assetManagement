using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;
using System;
using System.Collections.Generic;

namespace AssetManagement.Services
{
    public class MaintenanceRecordService
    {
        private readonly MaintenanceRecordRepository _maintenanceRecordRepository;

        public MaintenanceRecordService(MaintenanceRecordRepository maintenanceRecordRepository)
        {
            _maintenanceRecordRepository = maintenanceRecordRepository;
        }

        public bool AddMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            try
            {
                return _maintenanceRecordRepository.AddMaintenanceRecord(maintenanceRecord);
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to add maintenance record.", ex);
            }
        }

        public bool UpdateMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            try
            {
                return _maintenanceRecordRepository.UpdateMaintenanceRecord(maintenanceRecord);
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to update maintenance record.", ex);
            }
        }

        public bool DeleteMaintenanceRecord(int maintenanceId)
        {
            try
            {
                return _maintenanceRecordRepository.DeleteMaintenanceRecord(maintenanceId);
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to delete maintenance record.", ex);
            }
        }

        public MaintenanceRecord GetMaintenanceRecordById(int maintenanceId)
        {
            try
            {
                return _maintenanceRecordRepository.GetMaintenanceRecordById(maintenanceId);
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to retrieve maintenance record by ID.", ex);
            }
        }

        public IEnumerable<MaintenanceRecord> GetAllMaintenanceRecords()
        {
            try
            {
                return _maintenanceRecordRepository.GetAllMaintenanceRecords();
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to retrieve all maintenance records.", ex);
            }
        }

        public bool PerformMaintenance(int assetId, string maintenanceDate, string description, double cost)
        {
            try
            {
                return _maintenanceRecordRepository.PerformMaintenance(assetId, maintenanceDate, description, cost);
            }
            catch (Exception ex)
            {
                throw new MaintenanceException("Failed to perform maintenance.", ex);
            }
        }
    }
}