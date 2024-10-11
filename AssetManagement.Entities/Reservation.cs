namespace AssetManagement.Entities
{
    public class Reservation
    {
        private int _reservationId;
        private int _assetId;
        private int _employeeId;
        private DateTime _reservationDate;
        private DateTime _startDate;
        private DateTime _endDate;
        private string? _status;

        public int ReservationId
        {
            get { return _reservationId; }
            set { _reservationId = value; }
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

        public DateTime ReservationDate
        {
            get { return _reservationDate; }
            set { _reservationDate = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public string? Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}