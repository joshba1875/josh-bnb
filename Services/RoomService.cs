using josh_bnb.Models;
using josh_bnb.Context;
using Microsoft.AspNetCore.Mvc;
using josh_bnb.Interfaces;
using Microsoft.EntityFrameworkCore;
using josh_bnb.Controllers.ApiModels;
using System.Linq;

public class RoomService : IService<Room>
{
    private HotelBookingContext Context { get; set; }

    public RoomService(HotelBookingContext context)
    {
        Context = context;
    }

    public bool Validate(Room room)
    {
        return room != null && room.Id != 0 && room.Capacity > 0 && room.Name != null;
    }

    public IEnumerable<Room> GetBy(string capacity)
    {
        IEnumerable<Room> rtnVal = new List<Room>();
        int capacityInt;
        bool parseSuccess = int.TryParse(capacity, out capacityInt);
        if (parseSuccess)
        {
            using (Context)
            {
                rtnVal = [.. Context.Rooms.Where(x => x.Capacity == capacityInt)];
            }
        }
        return rtnVal;
    }

    public IEnumerable<Room> GetAll()
    {
        IEnumerable<Room> rtnVal;
        rtnVal = Context.Rooms.ToList();
        return rtnVal;
    }

    public IEnumerable<Room> GetByCriteria(Criteria criteria)
    {
        throw new NotImplementedException();
    }

    public Response Insert(Criteria criteria)
    {
        throw new NotImplementedException();
    }
}