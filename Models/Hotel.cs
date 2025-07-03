namespace josh_bnb.Models;

public class Hotel
{
    public int Id { get; set; }
    public String Name { get; set; }
    public virtual List<Room> Rooms { get; set; }
}
