namespace AssetManagement.Entities
{
    public class MaintenanceRecord
    {
        private int _maintenanceId;
        private int _assetId;
        private DateTime _maintenanceDate;
        private string? _description;
        private double _cost;

        public int MaintenanceId
        {
            get { return _maintenanceId; }
            set { _maintenanceId = value; }
        }

        public int AssetId
        {
            get { return _assetId; }
            set { _assetId = value; }
        }

        public DateTime MaintenanceDate
        {
            get { return _maintenanceDate; }
            set { _maintenanceDate = value; }
        }

        public string? Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
    }
}