using Microsoft.EntityFrameworkCore;
using KataHotelContext = RoomBooking.Dal.Models.KataHotelContext;
using RoomBooking.Dal.DataAccess;
using RoomBooking.Dal.Repository;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Dal.Repositories;
using Serilog;
using RoomBooking.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Log
string templateLog = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("./logs/ApiLog.txt", rollingInterval: RollingInterval.Day, 
                                                 outputTemplate: templateLog)
                .CreateLogger();


builder.Services.AddSingleton(Log.Logger);

//Injection de dépendance

//Booking
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

//Value
builder.Services.AddScoped<IValueService, RoomBooking.Domain.Services.ValueService>();
builder.Services.AddScoped<IValueRepository, ValueRepository>();

//Room
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

//User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Contexte d'accès la BDD

builder.Services.AddDbContext<KataHotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RoomDatabase")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
