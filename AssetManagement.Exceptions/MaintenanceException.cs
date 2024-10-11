namespace AssetManagement.Exceptions
{
    public class MaintenanceException : Exception
    {
        public MaintenanceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}