using Microsoft.EntityFrameworkCore;
using HotelNamespace;
using CountryNamespace;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using entityf.Data;
using entityf.Data.Configurations;

namespace APIContext;

public class API : IdentityDbContext<APIUser>
{
    public API(DbContextOptions<API> options) : base(options)
    {

    }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Country> Countries { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.Entity<Hotel>().HasData(new Hotel
        {
            HotelId = 1,
            Name = "Spa",
            Address = "Negril",
            CountryId = 1,
            Rating = 4.5
        }, new Hotel
        {
            HotelId = 2,
            Name = "Zlote",
            Address = "Warsaw",
            CountryId = 2,
            Rating = 5.0
        });
    }
}