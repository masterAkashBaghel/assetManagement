namespace AssetManagement.Exceptions
{
    public class AssetAllocationNotFoundException : Exception
    {
        // Constructor that takes an allocationId
        public AssetAllocationNotFoundException(int allocationId)
            : base($"Asset allocation with ID {allocationId} was not found.")
        {
        }

        // Constructor that takes a message and an inner exception
        public AssetAllocationNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}