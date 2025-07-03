namespace josh_bnb.Models;

public class Hotel : APIEntity
{
    public override string SearchKey => "Reference";
    public String Name { get; set; }
    public virtual List<Room> Rooms { get; set; }
}
