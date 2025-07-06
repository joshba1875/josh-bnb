using josh_bnb.Models;
using josh_bnb.Context;
using Microsoft.AspNetCore.Mvc;
using josh_bnb.Interfaces;
using Microsoft.EntityFrameworkCore;
using josh_bnb.Controllers.ApiModels;

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

    public IEnumerable<Hotel> GetBy(string name)
    {
        IEnumerable<Hotel> rtnVal;
        using (Context)
        {
            rtnVal = [.. Context.Hotels.Where(x => x.Name.ToLower() == name.ToLower()).Include(x => x.Rooms)];
        }
        return rtnVal;
    }

    public IEnumerable<Hotel> GetAll()
    {
        IEnumerable<Hotel> rtnVal;
        using (Context)
        {
            rtnVal = Context.Hotels.Include(x => x.Rooms).ToList();
        }

        return rtnVal;
    }

    public IEnumerable<Hotel> GetByCriteria(Criteria criteria)
    {
        throw new NotImplementedException();
    }

    public Response Insert(Criteria criteria)
    {
        throw new NotImplementedException();
    }

    public Response Delete(string reference)
    {
        throw new NotImplementedException();
    }

    public Response DeleteAll()
    {
        throw new NotImplementedException();
    }
}