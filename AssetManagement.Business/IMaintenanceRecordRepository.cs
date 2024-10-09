using AssetManagement.Entities;
using System.Collections.Generic;

namespace AssetManagement.Business
{
    public interface IMaintenanceRecordRepository
    {
        bool AddMaintenanceRecord(MaintenanceRecord maintenanceRecord);
        bool UpdateMaintenanceRecord(MaintenanceRecord maintenanceRecord);
        bool DeleteMaintenanceRecord(int maintenanceId);
        MaintenanceRecord GetMaintenanceRecordById(int maintenanceId);
        IEnumerable<MaintenanceRecord> GetAllMaintenanceRecords();
    }
}