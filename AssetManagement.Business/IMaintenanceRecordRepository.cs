using AssetManagement.Entities;
using System.Collections.Generic;

namespace AssetManagement.Business
{
    // Interface for the MaintenanceRecordRepository class
    public interface IMaintenanceRecordRepository
    {
        bool AddMaintenanceRecord(MaintenanceRecord maintenanceRecord);
        bool UpdateMaintenanceRecord(MaintenanceRecord maintenanceRecord);
        bool DeleteMaintenanceRecord(int maintenanceId);
        MaintenanceRecord GetMaintenanceRecordById(int maintenanceId);
        IEnumerable<MaintenanceRecord> GetAllMaintenanceRecords();

        bool PerformMaintenance(int maintenanceId, int assetId, string maintenanceDate, string description, double cost);
    }
}