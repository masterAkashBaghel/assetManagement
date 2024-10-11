using NUnit.Framework;
using AssetManagement.Entities;
using AssetManagement.Exceptions;
using AssetManagement.Business;
using System;

namespace AssetManagement.Tests
{
    [TestFixture]
    public class ReservationRepositoryTests
    {
        private ReservationRepository _reservationRepository;

        [SetUp]
        public void Setup()
        {
            _reservationRepository = new ReservationRepository();
        }

        [Test]
        public void ReserveAsset_ShouldThrowReservationException_WhenReservationFails()
        {
            var reservation = new Reservation
            {
                AssetId = 999,
                EmployeeId = 1,
                ReservationDate = DateTime.Now,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
                Status = "Reserved"
            };

            Assert.Throws<ReservationException>(() => _reservationRepository.ReserveAsset(reservation));
        }

        [Test]
        public void WithdrawReservation_ShouldThrowReservationException_WhenReservationNotFound()
        {
            Assert.Throws<ReservationException>(() => _reservationRepository.WithdrawReservation(999));
        }

        [Test]
        public void GetReservationById_ShouldThrowReservationException_WhenReservationNotFound()
        {
            Assert.Throws<ReservationException>(() => _reservationRepository.GetReservationById(999));
        }

        [Test]
        public void ReserveAsset_ShouldReserveAsset()
        {
            var reservation = new Reservation
            {
                AssetId = 1,
                EmployeeId = 1,
                ReservationDate = DateTime.Now,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
                Status = "Reserved"
            };

            var result = _reservationRepository.ReserveAsset(reservation);

            Assert.IsTrue(result);
        }

        [Test]
        public void WithdrawReservation_ShouldWithdrawReservation()
        {
            var reservation = new Reservation
            {
                AssetId = 1,
                EmployeeId = 1,
                ReservationDate = DateTime.Now,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
                Status = "Reserved"
            };

            _reservationRepository.ReserveAsset(reservation);
            var result = _reservationRepository.WithdrawReservation(reservation.ReservationId);

            Assert.IsTrue(result);
        }
    }
}