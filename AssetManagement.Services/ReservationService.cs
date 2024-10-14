using AssetManagement.Business;
using AssetManagement.Entities;
using AssetManagement.Exceptions;
using System.Collections.Generic;

namespace AssetManagement.Services
{
    // Service class for the ReservationRepository class that implements the IReservationRepository interface
    // Contains methods to reserve an asset, withdraw a reservation, get a reservation by ID, and get all reservations
    public class ReservationService
    {
        // Private field of type ReservationRepository that stores the ReservationRepository object
        private readonly ReservationRepository _reservationRepository;

        // Constructor that takes a ReservationRepository object as a parameter and assigns it to the private field
        public ReservationService(ReservationRepository reservationRepository)
        {
            // Assign the parameter to the private field
            _reservationRepository = reservationRepository;
        }
        // Method to reserve an asset
        public bool ReserveAsset(Reservation reservation)
        {
            try
            {
                // Call the ReserveAsset method of the ReservationRepository class and return the result
                return _reservationRepository.ReserveAsset(reservation);
            }
            catch (Exception ex)
            {
                // Throw a ReservationException if an exception occurs
                throw new ReservationException("Failed to reserve asset.", ex);
            }
        }

        // Method to withdraw a reservation
        public bool WithdrawReservation(int reservationId)
        {
            try
            {
                // Call the WithdrawReservation method of the ReservationRepository class and return the result
                return _reservationRepository.WithdrawReservation(reservationId);
            }
            catch (Exception ex)
            {
                // Throw a ReservationException if an exception occurs
                throw new ReservationException("Failed to withdraw reservation.", ex);
            }
        }


        // Method to get a reservation by its ID from the repository
        public Reservation GetReservationById(int reservationId)
        {
            try
            {
                // Call the GetReservationById method of the ReservationRepository class and return the result
                return _reservationRepository.GetReservationById(reservationId);
            }
            catch (Exception ex)
            {
                // Throw a ReservationException if an exception occurs
                throw new ReservationException("Failed to retrieve reservation by ID.", ex);
            }
        }

        // Method to get all reservations from the repository and return them as an IEnumerable
        public IEnumerable<Reservation> GetAllReservations()
        {
            try
            {
                // Call the GetAllReservations method of the ReservationRepository class and return the result  
                return _reservationRepository.GetAllReservations();
            }
            catch (Exception ex)
            {
                // Throw a ReservationException if an exception occurs
                throw new ReservationException("Failed to retrieve all reservations.", ex);
            }
        }
    }
}