using CinemaApi;
using CinemaApi.Entities;
using CinemaApi.Middleware;
using CinemaApi.Services;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICinemaHallService, CinemaHallService>();
builder.Services.AddDbContext<CinemaDbContext>(
    options => options
    //.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("CinemaDbConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});



var app = builder.Build();

app.UseCors("AllowAny");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<CinemaDbContext>();

var pendingMigration = dbContext.Database.GetPendingMigrations();
if (pendingMigration.Any())
{
    dbContext.Database.Migrate();
}

//DataSeeder.Seed(dbContext);
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
