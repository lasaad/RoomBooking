using RoomBooking.Api.Services.Interface;
using RoomBooking.Api.Services;
using Microsoft.EntityFrameworkCore;
using KataHotelContext = RoomBooking.Dal.Models.KataHotelContext;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.DataAccess;

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

//Test
//builder.Services.AddScoped<ITestService, TestService>();
//builder.Services.AddScoped<ITestRepository, TestRepository>();

//Room
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomDataAccess, RoomDataAccess>();

//User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDataAccess, UserDataAccess>();

//Contexte d'accès la BDD

builder.Services.AddDbContext<KataHotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=localhost\\SQLExpress;Initial Catalog=KataHotel;Integrated Security=True")));
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
