using Microsoft.EntityFrameworkCore;
using SistemaDeEnvios.Models;

namespace SistemaDeEnvios.Data;

public class ApiDbContext : DbContext
{
    public DbSet<Parcel> Parcels { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
}