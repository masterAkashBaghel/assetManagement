using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;
using System.Collections.Generic;

namespace AssetManagement.Services
{
    public class ReservationService
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public bool ReserveAsset(Reservation reservation)
        {
            try
            {
                return _reservationRepository.ReserveAsset(reservation);
            }
            catch (Exception ex)
            {
                throw new ReservationException("Failed to reserve asset.", ex);
            }
        }

        public bool WithdrawReservation(int reservationId)
        {
            try
            {
                return _reservationRepository.WithdrawReservation(reservationId);
            }
            catch (Exception ex)
            {
                throw new ReservationException("Failed to withdraw reservation.", ex);
            }
        }

        public Reservation GetReservationById(int reservationId)
        {
            try
            {
                return _reservationRepository.GetReservationById(reservationId);
            }
            catch (Exception ex)
            {
                throw new ReservationException("Failed to retrieve reservation by ID.", ex);
            }
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            try
            {
                return _reservationRepository.GetAllReservations();
            }
            catch (Exception ex)
            {
                throw new ReservationException("Failed to retrieve all reservations.", ex);
            }
        }
    }
}