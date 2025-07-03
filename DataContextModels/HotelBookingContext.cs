namespace josh_bnb.Context;

using System.CodeDom.Compiler;
using josh_bnb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class HotelBookingContext(DbContextOptions<HotelBookingContext> options) : DbContext(options)
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }

}

