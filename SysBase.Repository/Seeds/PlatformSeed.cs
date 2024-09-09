using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysBase.Core.Models;

namespace SysBase.Repository.Seeds
{
    internal class PlatformSeed : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.HasData(
                new Platform { Id = 1, Name = "Web" },
                new Platform { Id = 2, Name = "Android" },
                new Platform { Id = 3, Name = "Ios" },
                new Platform { Id = 4, Name = "Masaüstü" },
                new Platform { Id = 5, Name = "App (Android)" },
                new Platform { Id = 6, Name = "App (Ios)" }
            );
        }
    }
}
