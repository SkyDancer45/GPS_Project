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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data for User entity
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserID = "user1",
                UserPassword = "password1",
                OwnerID = "owner1",
                Email = "user1@example.com",
                Dob = new DateOnly(1990, 1, 1)
            },
            new User
            {
                UserID = "user2",
                UserPassword = "password2",
                OwnerID = "owner2",
                Email = "user2@example.com",
                Dob = new DateOnly(1992, 2, 2)
            }
        );
        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle{
                VehicleNum=1,
                OwnerId = "ownerId1",
                Model="model1",
                Make="make1",
                Latitude = 0.0001,
                Longitude=0.00001,
                Year=2021

            },
            new Vehicle{
                VehicleNum=2,
                OwnerId = "ownerId2",
                Model="model2",
                Make="make2",
                Latitude = 0.0002,
                Longitude=0.00002,
                Year=2022
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}
