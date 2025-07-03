using josh_bnb.Models;
using josh_bnb.Context;
using Microsoft.AspNetCore.Mvc;
using josh_bnb.Interfaces;
using Microsoft.EntityFrameworkCore;

public class HotelService : IService<Hotel>
{
    private HotelBookingContext Context { get; set; }
    public HotelService(HotelBookingContext context)
    {
        Context = context;
    }

    public bool Validate(Hotel hotel)
    {
        return hotel != null && hotel.Id != 0 && hotel.Name != null && hotel.Rooms != null;
    }

    public IEnumerable<Hotel> GetByName(String name)
    {
        IEnumerable<Hotel> rtnVal;
        using (Context)
        {
            rtnVal = [.. Context.Hotels.Where(x => x.Name == name)];
        }
        return rtnVal;
    }

    public IEnumerable<Hotel> GetAll()
    {
        IEnumerable<Hotel> rtnVal;
        using (Context)
        {
            rtnVal = Context.Hotels.Include(x => x.Rooms).ToList();
            Console.WriteLine("rtnVal: " + Context.Hotels.Count());
            Console.WriteLine("rtnVal: " + rtnVal.Count());
        }

        return rtnVal;
    }
}