using DomainModels;
using Infrastructure.DIConfigurations;
using Microsoft.EntityFrameworkCore;
using MyApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ServiceModule.Regsiter(builder.Services);
builder.Services.AddDbContext<Evs407Context>(x => x.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EVS-407;Trusted_Connection=True;"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
