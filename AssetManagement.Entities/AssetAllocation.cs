namespace AssetManagement.Entities
{
    public class AssetAllocation
    {
        // Properties for the AssetAllocation entity class ( corresponding to the AssetAllocation table in the database)
        public int AllocationId { get; set; }
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AllocationDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}