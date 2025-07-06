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
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public IActionResult GetRoomAvailability([FromQuery] BookingCriteria criteria)
    {
        try
        {
            IEnumerable<Booking> allBookings = _bookingService.GetAll();
            IEnumerable<Room> allRooms = _roomService.GetAll();
            return Ok(_roomBookingBusinessLayer.Filter(allRooms, allBookings, criteria));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet(Name = "GetAllBookings")]
    [ProducesResponseType(200)]
    public IActionResult GetAllBookings()
    {
        return Ok(_bookingService.GetAll());
    }

    [HttpGet(Name = "GetAllRooms")]
    [ProducesResponseType(200)]
    public IActionResult GetAllRooms()
    {
        return Ok(_roomService.GetAll());
    }

    [HttpGet(Name = "GetByReference")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult GetByReference(string reference)
    {
        try
        {
            IEnumerable<Booking> serviceResponse = _bookingService.GetBy(reference);
            if (serviceResponse.Count() > 0)
            {
                return Ok(serviceResponse);
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [HttpPut(Name = "PutBooking")]
    public IActionResult MakeBooking([FromQuery] BookingRequest bookingRequest)
    {
        try
        {
            IEnumerable<Booking> allBookings = _bookingService.GetAll();
            IEnumerable<Room> allRooms = _roomService.GetAll();
            bool isRequestValid = _roomBookingBusinessLayer.Validate(allRooms, allBookings, bookingRequest);
            if (isRequestValid)
            {
                Response serviceResponse = _bookingService.Insert(bookingRequest);
                return StatusCode(serviceResponse.StatusCode, serviceResponse.Message);
            }
            else
            {
                return StatusCode(400, "Room not booked, please check dates and RoomId requested");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpDelete(Name = "DeleteBooking")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public IActionResult DeleteBooking([FromQuery] string reference)
    {
        try
        {
            Response serviceResponse = _bookingService.Delete(reference);
            if (serviceResponse.StatusCode >= 200 && serviceResponse.StatusCode <= 299)
            {
                return Ok(serviceResponse);
            }
            else if (serviceResponse.StatusCode == 404)
            {
                return NotFound();
            }
            else
            {
                return StatusCode(serviceResponse.StatusCode, serviceResponse.Message);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete(Name = "DeleteAllBookings")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public IActionResult DeleteAll()
    {
        try
        {
            Response serviceResponse = _bookingService.DeleteAll();
            return StatusCode(serviceResponse.StatusCode, serviceResponse.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
