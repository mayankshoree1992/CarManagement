using Microsoft.EntityFrameworkCore;
using CarRepository;
using Microsoft.AspNetCore.Cors.Infrastructure;
using CarService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Car_DbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));
builder.Services.AddScoped<IAddCar, AddCarService>();
builder.Services.AddScoped<IGetCars, GetCarsService>();
builder.Services.AddTransient<ICarRepo, CarRepo>(); 

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
