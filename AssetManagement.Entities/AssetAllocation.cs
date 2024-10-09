namespace AssetManagement.Entities
{
    public class AssetAllocation
    {
        public int AllocationId { get; set; }
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AllocationDate { get; set; }
        public DateTime? ReturnDate { get; set; }


    }
}
