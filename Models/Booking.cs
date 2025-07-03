namespace josh_bnb.Models;

public class Booking : APIEntity
{
    public override string SearchKey => "Reference";
    public string Reference { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int People { get; set; }
    public virtual Room Room { get; set; }
}
