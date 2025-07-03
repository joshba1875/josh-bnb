namespace josh_bnb.Models;

public class Booking
{
    public int Id { get; set; }
    public string Reference { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Room_Id { get; set; }
    public virtual Room RoomBooked { get; set; }
}
