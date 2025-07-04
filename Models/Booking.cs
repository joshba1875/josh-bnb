namespace josh_bnb.Models;

public class Booking : APIEntity
{
    public override string SearchKey => "Reference";
    public string Reference { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumPeople { get; set; }
    public virtual Room Room { get; set; }
}
