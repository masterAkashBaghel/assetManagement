namespace AssetManagement.Entities
{
    public class Asset
    {
        private int _assetId;
        private string? _name;
        private string? _type;
        private string? _serialNumber;
        private DateTime _purchaseDate;
        private string? _location;
        private string? _status;
        private int _ownerId;

        public int AssetId
        {
            get { return _assetId; }
            set { _assetId = value; }
        }

        public string? Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string? Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string? SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }

        public DateTime PurchaseDate
        {
            get { return _purchaseDate; }
            set { _purchaseDate = value; }
        }

        public string? Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string? Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int OwnerId
        {
            get { return _ownerId; }
            set { _ownerId = value; }
        }
    }
}