
namespace GPS.Api.Data;
using Microsoft.EntityFrameworkCore;
using GPS.Api.Entities;

public class GpsContext : DbContext
{
  public GpsContext(DbContextOptions<GpsContext> options) : base(options)
  {
  }

  public DbSet<User> Users => Set<User>();
  public DbSet<Vehicle> Vehicles => Set<Vehicle>();
}

