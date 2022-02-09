using RoomBooking.Api.Services;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.DataAccess;
using RoomBooking.Dal.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Contexte d'accès la BDD
string connectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=KataHotel;Integrated Security=True";
builder.Services.AddDbContext<KataHotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString)));

//Injection de dépendance
builder.Services.AddSingleton<IBookingService, BookingService>();
builder.Services.AddSingleton<IBookingDataAccess, BookingDataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 