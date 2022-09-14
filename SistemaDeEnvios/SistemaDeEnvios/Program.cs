using Microsoft.EntityFrameworkCore;
using SistemaDeEnvios.Business.Interfaces;
using SistemaDeEnvios.Business.Services;
using SistemaDeEnvios.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Todo: Add real database here
builder.Services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase("SistemaDeEnvios"));
builder.Services.AddTransient<IParcelService, ParcelService>();

builder.Services.AddHealthChecks();
var app = builder.Build();
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
