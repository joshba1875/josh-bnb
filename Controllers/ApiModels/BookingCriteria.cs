namespace josh_bnb.Controllers.ApiModels;

public class BookingCriteria : Criteria
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumPeople { get; set; }
}