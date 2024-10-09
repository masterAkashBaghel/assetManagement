namespace AssetManagement.Entities
{
    public class MaintenanceRecord
    {
        public int MaintenanceId { get; set; }
        public int AssetId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }


    }
}
