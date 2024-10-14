using AssetManagement.Entities;
using System.Collections.Generic;

namespace AssetManagement.Business
{
    // Interface for the ReservationRepository class
    public interface IReservationRepository
    {
        bool ReserveAsset(Reservation reservation);
        bool WithdrawReservation(int reservationId);
        Reservation GetReservationById(int reservationId);
        IEnumerable<Reservation> GetAllReservations();
    }
}