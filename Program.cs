
using Microsoft.OpenApi.Models;
using josh_bnb.Interfaces;
using josh_bnb.Models;
using josh_bnb.Context;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using josh_bnb.BL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IService<Hotel>, HotelService>();
builder.Services.AddScoped<IService<Booking>, BookingService>();
builder.Services.AddScoped<IService<Room>, RoomService>();
builder.Services.AddScoped<IBusinessLayer<Room, Booking>, RoomBookingBusinessLayer>();
builder.Services.AddDbContext<HotelBookingContext>(options => options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("JoshBnB")), ServiceLifetime.Scoped);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
     {
         c.SwaggerDoc("v1", new OpenApiInfo { Title = "Josh BnB", Version = "v1" });
     });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Josh BnB Service v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seed in-memory database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HotelBookingContext>();
    context.Set<Room>().AddRange(
        new Room
        {
            Id = 1,
            Name = "Single 1",
            Capacity = 1,
            HotelId = 1
        },
        new Room
        {
            Id = 2,
            Name = "Double 1",
            Capacity = 2,
            HotelId = 1
        },
        new Room
        {
            Id = 3,
            Name = "Deluxe 1",
            Capacity = 3,
            HotelId = 1
        },
        new Room
        {
            Id = 4,
            Name = "Single 2",
            Capacity = 1,
            HotelId = 1
        },
        new Room
        {
            Id = 5,
            Name = "Double 2",
            Capacity = 2,
            HotelId = 1
        },
        new Room
        {
            Id = 6,
            Name = "Deluxe 2",
            Capacity = 3,
            HotelId = 1
        },
        new Room
        {
            Id = 7,
            Name = "Single 1",
            Capacity = 1,
            HotelId = 2
        },
        new Room
        {
            Id = 8,
            Name = "Double 1",
            Capacity = 2,
            HotelId = 2
        },
        new Room
        {
            Id = 9,
            Name = "Deluxe 1",
            Capacity = 3,
            HotelId = 2
        },
        new Room
        {
            Id = 10,
            Name = "Single 2",
            Capacity = 1,
            HotelId = 2
        },
        new Room
        {
            Id = 11,
            Name = "Double 2",
            Capacity = 2,
            HotelId = 2
        },
        new Room
        {
            Id = 12,
            Name = "Deluxe 2",
            Capacity = 3,
            HotelId = 2
        },
        new Room
        {
            Id = 13,
            Name = "Single 1",
            Capacity = 1,
            HotelId = 3
        },
        new Room
        {
            Id = 14,
            Name = "Double 1",
            Capacity = 2,
            HotelId = 3
        },
        new Room
        {
            Id = 15,
            Name = "Deluxe 1",
            Capacity = 3,
            HotelId = 3
        },
        new Room
        {
            Id = 16,
            Name = "Single 2",
            Capacity = 1,
            HotelId = 3
        },
        new Room
        {
            Id = 17,
            Name = "Double 2",
            Capacity = 2,
            HotelId = 3
        },
        new Room
        {
            Id = 18,
            Name = "Deluxe 2",
            Capacity = 3,
            HotelId = 3
        }
    );

    context.Set<Hotel>().AddRange(
                    new Hotel
                    {
                        Id = 1,
                        Name = "Josh's Campervan",
                        Rooms = context.Rooms.Where(x => x.HotelId == 1).ToList()
                    },
                    new Hotel
                    {
                        Id = 2,
                        Name = "Hamilton DoubleTree",
                        Rooms = context.Rooms.Where(x => x.HotelId == 2).ToList()
                    },
                    new Hotel
                    {
                        Id = 3,
                        Name = "Blythswood Spa",
                        Rooms = context.Rooms.Where(x => x.HotelId == 3).ToList()
                    }
                );

    context.SaveChanges();
}

app.Run();
