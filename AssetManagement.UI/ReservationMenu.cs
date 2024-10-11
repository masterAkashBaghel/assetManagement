using System;
using AssetManagement.Services;
using AssetManagement.Entities;
using AssetManagement.Business;

namespace AssetManagement.UI
{
    public static class ReservationMenu
    {
        public static void Show()
        {
            var reservationService = new ReservationService(new ReservationRepository());

            while (true)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Reservation Management");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1. Reserve Asset");
                Console.WriteLine("2. Withdraw Reservation");
                Console.WriteLine("3. View Reservation by ID");
                Console.WriteLine("4. View All Reservations");
                Console.WriteLine("5. Back to Main Menu");
                Console.WriteLine("---------------------------------------------");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ReserveAsset(reservationService);
                        break;
                    case "2":
                        WithdrawReservation(reservationService);
                        break;
                    case "3":
                        ViewReservationById(reservationService);
                        break;
                    case "4":
                        ViewAllReservations(reservationService);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void ReserveAsset(ReservationService reservationService)
        {
            var reservation = new Reservation();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Reserve Asset");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Enter reservation ID: ");
            reservation.ReservationId = int.Parse(Console.ReadLine());
            Console.Write("Enter Asset ID: ");
            reservation.AssetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee ID: ");
            reservation.EmployeeId = int.Parse(Console.ReadLine());
            Console.Write("Enter Reservation Date (yyyy-mm-dd): ");
            reservation.ReservationDate = DateTime.Parse(Console.ReadLine());

            if (reservationService.ReserveAsset(reservation))
            {
                Console.WriteLine("Asset reserved successfully.");
            }
            else
            {
                Console.WriteLine("Failed to reserve asset.");
            }
            Console.WriteLine("---------------------------------------------");
        }

        static void WithdrawReservation(ReservationService reservationService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Withdraw Reservation");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Enter Reservation ID: ");
            var reservationId = int.Parse(Console.ReadLine());

            if (reservationService.WithdrawReservation(reservationId))
            {
                Console.WriteLine("Reservation withdrawn successfully.");
            }
            else
            {
                Console.WriteLine("Failed to withdraw reservation.");
            }
            Console.WriteLine("---------------------------------------------");
        }

        static void ViewReservationById(ReservationService reservationService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("View Reservation by ID");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Enter Reservation ID: ");
            var reservationId = int.Parse(Console.ReadLine());

            var reservation = reservationService.GetReservationById(reservationId);
            if (reservation != null)
            {
                // Print table header
                Console.WriteLine("{0,-5} | {1,-8} | {2,-10} | {3,-20}", "ID", "Asset ID", "Emp ID", "Reservation Date");
                Console.WriteLine(new string('-', 50));

                // Print table row
                Console.WriteLine("{0,-5} | {1,-8} | {2,-10} | {3,-20}",
                    reservation.ReservationId,
                    reservation.AssetId,
                    reservation.EmployeeId,
                    reservation.ReservationDate.ToString("yyyy-MM-dd"));
            }
            else
            {
                Console.WriteLine("Reservation not found.");
            }
            Console.WriteLine("---------------------------------------------");
        }

        static void ViewAllReservations(ReservationService reservationService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("View All Reservations");
            Console.WriteLine("---------------------------------------------");

            var reservations = reservationService.GetAllReservations();

            // Print table header
            Console.WriteLine("{0,-5} | {1,-8} | {2,-10} | {3,-20}", "ID", "Asset ID", "Emp ID", "Reservation Date");
            Console.WriteLine(new string('-', 50));

            // Print table rows
            foreach (var reservation in reservations)
            {
                Console.WriteLine("{0,-5} | {1,-8} | {2,-10} | {3,-20}",
                    reservation.ReservationId,
                    reservation.AssetId,
                    reservation.EmployeeId,
                    reservation.ReservationDate.ToString("yyyy-MM-dd"));
            }

            Console.WriteLine("---------------------------------------------");
        }
    }
}