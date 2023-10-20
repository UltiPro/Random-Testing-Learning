using CountryNamespace;
using HotelNamespace;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace entityf.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new Country
            {
                CountryId = 1,
                Name = "United States Of America",
                ShortName = "USA",
            }, new Country
            {
                CountryId = 2,
                Name = "Poland",
                ShortName = "PL",
            });
        }
    }
}
