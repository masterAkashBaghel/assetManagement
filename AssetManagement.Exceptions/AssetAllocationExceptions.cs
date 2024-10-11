namespace AssetManagement.Exceptions
{
    public class AssetAllocationNotFoundException : Exception
    {
        public AssetAllocationNotFoundException(int allocationId)
            : base($"Asset allocation with ID {allocationId} was not found.")
        {
        }
    }

    public class InvalidAssetAllocationException : Exception
    {
        public InvalidAssetAllocationException(string message)
            : base(message)
        {
        }
    }
    namespace AssetManagement.Exceptions
    {
        public class AssetAllocationNotFoundException : Exception
        {
            public AssetAllocationNotFoundException(int allocationId)
                : base($"Asset allocation with ID {allocationId} was not found.")
            {
            }
        }

        public class InvalidAssetAllocationException : Exception
        {
            public InvalidAssetAllocationException(string message)
                : base(message)
            {
            }
        }

        public class AssetAllocationException : Exception
        {
            public AssetAllocationException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }

        public class AssetMaintenanceException : Exception
        {
            public AssetMaintenanceException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }

        public class AssetReservationException : Exception
        {
            public AssetReservationException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }
    }
}