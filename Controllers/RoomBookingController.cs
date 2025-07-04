using Microsoft.AspNetCore.Mvc;
using josh_bnb.Controllers.ApiModels;
using josh_bnb.Models;
using josh_bnb.Interfaces;

namespace josh_bnb.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RoomBookingController : ControllerBase
{
    private readonly ILogger<RoomBookingController> _logger;
    private readonly IService<Booking> _bookingService;
    private readonly IService<Room> _roomService;
    private readonly IBusinessLayer<Room, Booking> _roomBookingBusinessLayer;


    public RoomBookingController(ILogger<RoomBookingController> logger, IService<Booking> bookingService, IService<Room> roomService, IBusinessLayer<Room, Booking> roomBookingBusinessLayer)
    {
        _logger = logger;
        _bookingService = bookingService;
        _roomService = roomService;
        _roomBookingBusinessLayer = roomBookingBusinessLayer;
    }

    [HttpGet(Name = "GetRoomAvailability")]
    public IEnumerable<Room> GetRoomAvailability([FromQuery] BookingCriteria criteria)
    {
        IEnumerable<Booking> allBookings = _bookingService.GetAll();
        IEnumerable<Room> allRooms = _roomService.GetAll();
        return _roomBookingBusinessLayer.Filter(allRooms, allBookings, criteria);
    }

    [HttpGet(Name = "GetAllBookings")]
    public IEnumerable<Booking> GetAllBookings()
    {
        return _bookingService.GetAll();
    }

    [HttpGet(Name = "GetAllRooms")]
    public IEnumerable<Room> GetAllRooms()
    {
        return _roomService.GetAll();
    }

    [HttpGet(Name = "GetByReference")]
    public IEnumerable<Booking> GetByReference(string reference)
    {
        return _bookingService.GetBy(reference);
    }

    [HttpPut(Name = "PutBooking")]
    public Response MakeBooking([FromQuery] BookingRequest bookingRequest)
    {
        IEnumerable<Booking> allBookings = _bookingService.GetAll();
        IEnumerable<Room> allRooms = _roomService.GetAll();
        bool isRequestValid = _roomBookingBusinessLayer.Validate(allRooms, allBookings, bookingRequest);
        if (isRequestValid)
        {
            return _bookingService.Insert(bookingRequest);
        }
        else
        {
            return new Response { Status = 400, Message = "Room not booked, please check dates and RoomId requested" };
        }
    }
}
