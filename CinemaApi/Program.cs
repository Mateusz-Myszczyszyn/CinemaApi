using CinemaApi;
using CinemaApi.Entities;
using CinemaApi.Middleware;
using CinemaApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<ICinemaService, CinemaService>();

builder.Services.AddDbContext<CinemaDbContext>(
    options => options
    //.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("CinemaDbConnection")));


var app = builder.Build();

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
