namespace AssetManagement.Entities;
public class Reservation
{

    // Properties for the Reservations entity class ( corresponding to the Reservations table in the database)
    public int ReservationId { get; set; }
    public int AssetId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? Status { get; set; }
}