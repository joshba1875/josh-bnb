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
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult GetByName(string name)
    {
        IEnumerable<Hotel> serviceResponse = _hotelService.GetBy(name);
        if (serviceResponse.Count() > 0)
        {
            return Ok(serviceResponse);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet(Name = "GetAllHotels")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult GetAll()
    {
        IEnumerable<Hotel> serviceResponse = _hotelService.GetAll();
        if (serviceResponse.Count() > 0)
        {
            return Ok(serviceResponse);
        }
        else
        {
            return NotFound();
        }
    }
}
