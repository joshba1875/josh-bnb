using josh_bnb.Models;
using josh_bnb.Context;
using josh_bnb.Interfaces;
using Microsoft.EntityFrameworkCore;
using josh_bnb.Controllers.ApiModels;

public class BookingService : IService<Booking>
{
    private HotelBookingContext Context { get; set; }

    public BookingService(HotelBookingContext context)
    {
        Context = context;
    }

    public bool Validate(Booking booking)
    {
        return booking != null && booking.Reference != null && booking.CheckInDate < booking.CheckOutDate;
    }

    public IEnumerable<Booking> GetBy(string reference)
    {
        IEnumerable<Booking> rtnVal;
        rtnVal = [.. Context.Bookings.Where(x => x.Reference.ToLower() == reference.ToLower()).Include(x => x.Room)];
        return rtnVal;
    }

    public IEnumerable<Booking> GetAll()
    {
        IEnumerable<Booking> rtnVal;
        rtnVal = Context.Bookings.Include(x => x.Room).ToList();
        return rtnVal;
    }

    public Response Insert(Criteria bookingRequest)
    {
        BookingRequest request = (BookingRequest)bookingRequest;
        // Generate a booking reference
        string reference = Guid.NewGuid().ToString();
        Response rtnVal = new Response { StatusCode = 201, Message = "Booking Successful | Reference: " + reference };
        // Construct domain level object from request
        Booking newBooking = new Booking() { CheckInDate = request.CheckInDate, CheckOutDate = request.CheckOutDate, NumPeople = request.NumPeople, Reference = reference };
        // Get the Room
        Room? room = Context.Rooms.FirstOrDefault(x => x.Id == request.RoomId);
        // Validate logical props
        bool validateResult = this.Validate(newBooking);
        if (validateResult && room != null)
        {
            newBooking.Room = room;
            Context.Bookings.Add(newBooking);
            Context.SaveChanges();
            Console.WriteLine("BookingsCount: " + Context.Bookings.Count());
        }
        else
        {
            rtnVal = new Response { StatusCode = 400, Message = "Booking Unsuccessful, please inspect request" };
        }
        return rtnVal;
    }

    public Response Delete(string reference)
    {
        Response rtnVal;
        if (Context.Bookings.Any(x => x.Reference == reference))
        {
            var bookings = Context.Bookings.Where(x => x.Reference == reference);
            Context.Bookings.RemoveRange(bookings);
            Context.SaveChanges();
            rtnVal = new Response { StatusCode = 200, Message = $"Booking successfully deleted for | Reference: {reference}" };
        }
        else
        {
            rtnVal = new Response { StatusCode = 404, Message = $"Booking not found for | Reference: {reference}" };
        }

        return rtnVal;
    }

    public Response DeleteAll()
    {
        Context.Bookings.RemoveRange(Context.Bookings);
        Context.SaveChanges();
        return new Response { StatusCode = 200, Message = "All Bookings Deleted" };
    }
}