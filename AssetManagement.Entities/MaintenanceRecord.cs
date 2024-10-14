namespace AssetManagement.Entities
{
    public class MaintenanceRecord
    {
        // Properties for the MaintenanceRecord entity class ( corresponding to the MaintenanceRecord table in the database)
        public int MaintenanceId { get; set; }
        public int AssetId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string? Description { get; set; }
        public double Cost { get; set; }
    }
}