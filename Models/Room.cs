namespace josh_bnb.Models;

public class Room : APIEntity
{
    public override string SearchKey => "Reference";
    public int HotelId { get; set; }
    public int Capacity { get; set; }
    public string Name { get; set; }
}
