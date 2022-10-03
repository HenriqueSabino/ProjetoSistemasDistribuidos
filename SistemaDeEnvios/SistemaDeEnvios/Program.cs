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

builder.Services.AddDbContext<ApiDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IParcelService, ParcelService>();

builder.Services.AddSingleton(sp => RabbitMQHutch.CreateBus(builder.Configuration["RabbitMQ:URL"]));

builder.Services.AddHealthChecks();
var app = builder.Build();
app.MapHealthChecks("/health");


using (var serviceScope = app.Services.CreateScope())
{
    var serviceDb = serviceScope.ServiceProvider.GetService<ApiDbContext>();
    serviceDb.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
