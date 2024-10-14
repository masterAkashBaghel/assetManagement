namespace AssetManagement.Exceptions
{
    // Exception class for when a maintenance exception occurs
    public class MaintenanceException : Exception
    {
        // Default constructor
        public MaintenanceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}