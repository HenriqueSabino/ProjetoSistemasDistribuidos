using Microsoft.EntityFrameworkCore;
using BlobStorage.Data.Models;

namespace BlobStorage.Data;

public class ApiDbContext : DbContext
{
    public DbSet<Blob> Blobs { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
}