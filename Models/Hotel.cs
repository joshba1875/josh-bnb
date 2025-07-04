namespace josh_bnb.Models;

public class Hotel : APIEntity
{
    public override string SearchKey => "Name";
    public String Name { get; set; }
    public virtual List<Room> Rooms { get; set; }
}
