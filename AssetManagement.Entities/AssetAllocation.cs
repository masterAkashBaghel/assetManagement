namespace AssetManagement.Entities
{
    public class AssetAllocation
    {
        private int _allocationId;
        private int _assetId;
        private int _employeeId;
        private DateTime _allocationDate;
        private DateTime? _returnDate;

        public int AllocationId
        {
            get { return _allocationId; }
            set { _allocationId = value; }
        }

        public int AssetId
        {
            get { return _assetId; }
            set { _assetId = value; }
        }

        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        public DateTime AllocationDate
        {
            get { return _allocationDate; }
            set { _allocationDate = value; }
        }

        public DateTime? ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }
    }
}