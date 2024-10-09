using AssetManagement.Business;
using AssetManagement.Entities;

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
            return _maintenanceRecordRepository.AddMaintenanceRecord(maintenanceRecord);
        }

        public bool UpdateMaintenanceRecord(MaintenanceRecord maintenanceRecord)
        {
            return _maintenanceRecordRepository.UpdateMaintenanceRecord(maintenanceRecord);
        }

        public bool DeleteMaintenanceRecord(int maintenanceId)
        {
            return _maintenanceRecordRepository.DeleteMaintenanceRecord(maintenanceId);
        }

        public MaintenanceRecord GetMaintenanceRecordById(int maintenanceId)
        {
            return _maintenanceRecordRepository.GetMaintenanceRecordById(maintenanceId);
        }

        public IEnumerable<MaintenanceRecord> GetAllMaintenanceRecords()
        {
            return _maintenanceRecordRepository.GetAllMaintenanceRecords();
        }
    }
}
