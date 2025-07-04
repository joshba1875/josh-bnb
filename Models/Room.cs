namespace josh_bnb.Models;

public class Room : APIEntity
{
    public override string SearchKey => "Capacity";
    public int HotelId { get; set; }
    public int Capacity { get; set; }
    public string Name { get; set; }
}
