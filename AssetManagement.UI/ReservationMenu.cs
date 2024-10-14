using System;
using AssetManagement.Services;
using AssetManagement.Entities;
using AssetManagement.Business;

namespace AssetManagement.UI
{
    public static class ReservationMenu
    {
        // Method to display the reservation management menu
        public static void Show()
        {
            // Initialize the ReservationService with an instance of ReservationRepository
            var reservationService = new ReservationService(new ReservationRepository());

            // Infinite loop to keep the menu running until the user chooses to exit
            while (true)
            {
                // Display the menu options
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

                // Handle the user's selection
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
                        return; // Exit the menu
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Method to reserve an asset
        static void ReserveAsset(ReservationService reservationService)
        {
            var reservation = new Reservation();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Reserve Asset");
            Console.WriteLine("---------------------------------------------");

            // Prompt the user to enter reservation details
            Console.Write("Enter reservation ID: ");
            reservation.ReservationId = int.Parse(Console.ReadLine());
            Console.Write("Enter Asset ID: ");
            reservation.AssetId = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee ID: ");
            reservation.EmployeeId = int.Parse(Console.ReadLine());
            Console.Write("Enter Reservation Date (yyyy-mm-dd): ");
            reservation.ReservationDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Start Date (yyyy-mm-dd): ");
            reservation.StartDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter End Date (yyyy-mm-dd): ");
            reservation.EndDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Status: ");
            reservation.Status = Console.ReadLine();

            // Ensure the dates are within the valid range for SQL Server
            if (reservation.ReservationDate < new DateTime(1753, 1, 1) || reservation.StartDate < new DateTime(1753, 1, 1) || reservation.EndDate < new DateTime(1753, 1, 1))
            {
                Console.WriteLine("DateTime value is out of range for SQL Server.");
                return;
            }

            // Attempt to reserve the asset using the ReservationService
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

        // Method to withdraw a reservation
        static void WithdrawReservation(ReservationService reservationService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Withdraw Reservation");
            Console.WriteLine("---------------------------------------------");

            // Prompt the user to enter the reservation ID to withdraw
            Console.Write("Enter Reservation ID: ");
            var reservationId = int.Parse(Console.ReadLine());

            // Attempt to withdraw the reservation using the ReservationService
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

        // Method to view a reservation by its ID
        static void ViewReservationById(ReservationService reservationService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("View Reservation by ID");
            Console.WriteLine("---------------------------------------------");

            // Prompt the user to enter the reservation ID to view
            Console.Write("Enter Reservation ID: ");
            var reservationId = int.Parse(Console.ReadLine());

            // Retrieve the reservation using the ReservationService
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

        // Method to view all reservations
        static void ViewAllReservations(ReservationService reservationService)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("View All Reservations");
            Console.WriteLine("---------------------------------------------");

            // Retrieve all reservations using the ReservationService
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