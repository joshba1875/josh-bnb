using Microsoft.AspNetCore.Mvc;
using josh_bnb.Models;

namespace josh_bnb.Controllers;

[ApiController]
[Route("[controller]")]
public class HotelController : ControllerBase
{
    private readonly ILogger<HotelController> _logger;

    public HotelController(ILogger<HotelController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetHotels")]
    public IEnumerable<Hotel> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Hotel
        {
            Id = index,
            Name = "Hotel " + index
        })
        .ToArray();
    }
}
