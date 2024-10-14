using System;

namespace AssetManagement.Exceptions
{
    // Exception class for when a reservation exception occurs
    public class ReservationException : Exception
    {

        // Default constructor

        public ReservationException() { }

        // Constructor with message parameter
        public ReservationException(string message) : base(message) { }
        // Constructor with message and inner exception parameters
        public ReservationException(string message, Exception inner) : base(message, inner) { }
    }
}