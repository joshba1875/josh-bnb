using josh_bnb.Controllers.ApiModels;
using josh_bnb.Interfaces;
using josh_bnb.Models;

namespace josh_bnb.BL;

/// <summary>
/// Represents a business layer to combine multiple domains used in a room booking system
/// </summary>

public class RoomBookingBusinessLayer : IBusinessLayer<Room, Booking>
{
    public IEnumerable<Room> Filter(IEnumerable<Room> rooms, IEnumerable<Booking> bookings, Criteria criteria)
    {
        BookingCriteria bookingCriteria = (BookingCriteria)criteria;
        IEnumerable<Room> rtnVal;
        // Get all rooms with appropriate capacity
        IEnumerable<Room> suitableRooms = rooms.Where(x => x.Capacity >= bookingCriteria.NumPeople);
        // Check which of these rooms have bookings
        IEnumerable<Booking> bookingsForSuitableRooms = bookings.Where(x => suitableRooms.Any(y => y.Id == x.Room.Id));
        // Filter out suitable rooms with date clash
        rtnVal = suitableRooms.Where(x => !bookingsForSuitableRooms.Any(y => x.Id == y.Room.Id &&
                                                                        (y.CheckInDate == bookingCriteria.CheckInDate ||
                                                                         y.CheckOutDate == bookingCriteria.CheckOutDate ||
                                                                         (y.CheckInDate < bookingCriteria.CheckInDate && y.CheckOutDate > bookingCriteria.CheckInDate) ||
                                                                         (y.CheckInDate > bookingCriteria.CheckInDate && bookingCriteria.CheckOutDate > y.CheckInDate))));
        return rtnVal;
    }

    public bool Validate(IEnumerable<Room> rooms, IEnumerable<Booking> bookings, Criteria criteria)
    {
        bool rtnVal = false;
        BookingRequest bookingRequest = (BookingRequest)criteria;
        // Basic, logical attribute level validation
        if (bookingRequest.NumPeople > 0 && bookingRequest.CheckInDate < bookingRequest.CheckOutDate)
        {
            // Filter available rooms per request
            IEnumerable<Room> availableRooms = Filter(rooms, bookings, criteria);
            if (availableRooms.Any(x => x.Id == bookingRequest.RoomId))
            {
                // Requested room available
                rtnVal = true;
            }
        }
        return rtnVal;
    }
}