using RoomBooking.Api.Services.Interface;
using RoomBooking.Api.Services;
using Microsoft.EntityFrameworkCore;
using KataHotelContext = RoomBooking.Dal.Models.KataHotelContext;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.DataAccess;
using RoomBooking.Dal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Injection de dépendance

//Booking
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingDataAccess, BookingDataAccess>();

//Value
builder.Services.AddScoped<RoomBooking.Domain.Interfaces.Services.IValueService, RoomBooking.Domain.Services.ValueService>();
builder.Services.AddScoped<RoomBooking.Domain.Interfaces.Repositories.IValueRepository, RoomBooking.Dal.Repositories.ValueRepository>();

//Room
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomDataAccess, RoomDataAccess>();

//User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDataAccess, UserDataAccess>();

//Contexte d'accès la BDD

builder.Services.AddDbContext<KataHotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RoomDatabase")));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
