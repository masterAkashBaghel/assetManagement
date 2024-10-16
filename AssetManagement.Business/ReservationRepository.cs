using AssetManagement.Entities;
using AssetManagement.Exceptions;
using AssetManagement.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AssetManagement.Business
{
    public class ReservationRepository : IReservationRepository
    {
        public bool ReserveAsset(Reservation reservation)
        {
            try
            {
                ValidateDateTime(reservation.ReservationDate);
                ValidateDateTime(reservation.StartDate);
                ValidateDateTime(reservation.EndDate);

                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("INSERT INTO Reservations (reservation_id,asset_id, employee_id, reservation_date, start_date, end_date, status) VALUES (@ReservationId,@assetId, @employeeId, @reservationDate, @startDate, @endDate, @status)", connection);
                command.Parameters.AddWithValue("@ReservationId", reservation.ReservationId);
                command.Parameters.AddWithValue("@assetId", reservation.AssetId);
                command.Parameters.AddWithValue("@employeeId", reservation.EmployeeId);
                command.Parameters.AddWithValue("@reservationDate", reservation.ReservationDate);
                command.Parameters.AddWithValue("@startDate", reservation.StartDate);
                command.Parameters.AddWithValue("@endDate", reservation.EndDate);
                command.Parameters.AddWithValue("@status", reservation.Status);


                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new ReservationException("Failed to reserve asset --->.", ex);
            }
        }
        private void ValidateDateTime(DateTime dateTime)
        {
            if (dateTime < new DateTime(1753, 1, 1) || dateTime > (DateTime)System.Data.SqlTypes.SqlDateTime.MaxValue)
            {
                throw new ReservationException("DateTime value is out of range for SQL Server.");
            }
        }

        public bool WithdrawReservation(int reservationId)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("DELETE FROM Reservations WHERE reservation_id = @reservationId", connection);
                command.Parameters.AddWithValue("@reservationId", reservationId);


                return command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new ReservationException("Failed to withdraw reservation.", ex);
            }
        }

        public Reservation? GetReservationById(int reservationId)
        {
            try
            {
                using var connection = DBConnection.GetConnection();
                var command = new SqlCommand("SELECT * FROM Reservations WHERE reservation_id = @reservationId", connection);
                command.Parameters.AddWithValue("@reservationId", reservationId);


                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Reservation
                    {
                        ReservationId = (int)reader["reservation_id"],
                        AssetId = (int)reader["asset_id"],
                        EmployeeId = (int)reader["employee_id"],
                        ReservationDate = (DateTime)reader["reservation_date"],
                        StartDate = (DateTime)reader["start_date"],
                        EndDate = (DateTime)reader["end_date"],
                        Status = (string)reader["status"]
                    };
                }
                return null;
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
                var reservations = new List<Reservation>();
                using (var connection = DBConnection.GetConnection())
                {
                    var command = new SqlCommand("SELECT * FROM Reservations", connection);


                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        reservations.Add(new Reservation
                        {
                            ReservationId = (int)reader["reservation_id"],
                            AssetId = (int)reader["asset_id"],
                            EmployeeId = (int)reader["employee_id"],
                            ReservationDate = (DateTime)reader["reservation_date"],
                            StartDate = (DateTime)reader["start_date"],
                            EndDate = (DateTime)reader["end_date"],
                            Status = (string)reader["status"]
                        });
                    }
                }
                return reservations;
            }
            catch (Exception ex)
            {
                throw new ReservationException("Failed to retrieve all reservations.", ex);
            }
        }
    }
}