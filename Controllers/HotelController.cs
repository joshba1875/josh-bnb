using Microsoft.AspNetCore.Mvc;
using josh_bnb.Models;
using josh_bnb.Interfaces;

namespace josh_bnb.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HotelController : ControllerBase
{
    private readonly ILogger<HotelController> _logger;
    private readonly IService<Hotel> _hotelService;

    public HotelController(ILogger<HotelController> logger, IService<Hotel> hotelService)
    {
        _logger = logger;
        _hotelService = hotelService;
    }

    [HttpGet(Name = "GetByName")]
    public IEnumerable<Hotel> GetByName(string name)
    {
        return _hotelService.GetBy(name);
    }

    [HttpGet(Name = "GetAllHotels")]
    public IEnumerable<Hotel> GetAll()
    {
        return _hotelService.GetAll();
    }
}
