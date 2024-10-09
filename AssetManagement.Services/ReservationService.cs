using AssetManagement.Business;
using AssetManagement.Entities;

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
            return _reservationRepository.ReserveAsset(reservation);
        }

        public bool WithdrawReservation(int reservationId)
        {
            return _reservationRepository.WithdrawReservation(reservationId);
        }

        public Reservation GetReservationById(int reservationId)
        {
            return _reservationRepository.GetReservationById(reservationId);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }
    }
}
