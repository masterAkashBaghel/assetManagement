using System;

namespace AssetManagement.Exceptions
{
    public class ReservationException : Exception
    {
        public ReservationException() { }

        public ReservationException(string message) : base(message) { }

        public ReservationException(string message, Exception inner) : base(message, inner) { }
    }
}