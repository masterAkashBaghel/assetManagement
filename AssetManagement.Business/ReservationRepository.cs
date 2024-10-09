using AssetManagement.Entities;
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
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("INSERT INTO Reservations (asset_id, employee_id, reservation_date, start_date, end_date, status) VALUES (@assetId, @employeeId, @reservationDate, @startDate, @endDate, @status)", connection);
            command.Parameters.AddWithValue("@assetId", reservation.AssetId);
            command.Parameters.AddWithValue("@employeeId", reservation.EmployeeId);
            command.Parameters.AddWithValue("@reservationDate", reservation.ReservationDate);
            command.Parameters.AddWithValue("@startDate", reservation.StartDate);
            command.Parameters.AddWithValue("@endDate", reservation.EndDate);
            command.Parameters.AddWithValue("@status", reservation.Status);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public bool WithdrawReservation(int reservationId)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("DELETE FROM Reservations WHERE reservation_id = @reservationId", connection);
            command.Parameters.AddWithValue("@reservationId", reservationId);

            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        public Reservation GetReservationById(int reservationId)
        {
            using var connection = DBConnection.GetConnection();
            var command = new SqlCommand("SELECT * FROM Reservations WHERE reservation_id = @reservationId", connection);
            command.Parameters.AddWithValue("@reservationId", reservationId);

            connection.Open();
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

        public IEnumerable<Reservation> GetAllReservations()
        {
            var reservations = new List<Reservation>();
            using (var connection = DBConnection.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Reservations", connection);

                connection.Open();
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
    }
}
