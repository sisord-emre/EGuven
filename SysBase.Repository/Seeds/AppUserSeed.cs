using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Repository.Seeds
{
    internal class AppUserSeed : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(
                new AppUser
                {
                    Id = "8ae560eb-41bf-4254-ad04-b8272ea2b1e0",
                    Name = "EMRE",
                    SurName = "ARIĞ",
                    MenuPermissions = "[{\"MenuId\":4,\"ControllerName\":\"User\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":25,\"ControllerName\":\"Role\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":7,\"ControllerName\":\"Config\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":9,\"ControllerName\":\"Language\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":13,\"ControllerName\":\"PanelLanguage\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":17,\"ControllerName\":\"Notification\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":20,\"ControllerName\":\"Page\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true}]",
                    Status = true,
                    CreatedDate = DateTime.Parse("2023-07-20 17:28:27"),
                    UserName = "emre-arig",
                    NormalizedUserName = "EMRE-ARIG",
                    Email = "emre@emre.com",
                    NormalizedEmail = "EMRE@EMRE.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEOmlDWzSQMNUIAWKzClGkBB0COUEjon7eOnYWW08nggCodqff3UluDvAxQ0tacIIVA==",
                    SecurityStamp = "UX6BWGARNYYPRP3JBC3D7APUJGSAM5FU",
                    ConcurrencyStamp = "8b35e72a-c27f-4b8a-b28d-d31eb1b510fc",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    NotificationStatus = true
                },
                new AppUser
                {
                    Id = "e6d7e0f3-ba29-422a-8e53-97bd03008bce",
                    Name = "Yunus",
                    SurName = "Karaca",
                    MenuPermissions = "[{\"MenuId\":4,\"ControllerName\":\"User\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":25,\"ControllerName\":\"Role\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":7,\"ControllerName\":\"Config\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":9,\"ControllerName\":\"Language\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":13,\"ControllerName\":\"PanelLanguage\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":17,\"ControllerName\":\"Notification\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":20,\"ControllerName\":\"Page\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true}]",
                    Status = true,
                    CreatedDate = DateTime.Parse("2023-08-20 09:23:47"),
                    UserName = "yunus-karaca",
                    NormalizedUserName = "YUNUS-KARACA",
                    Email = "yunus.karaca@sisord.com",
                    NormalizedEmail = "YUNUS.KARACA@SISORD.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEBDAejxQhz1ei67Mo/LoYm2TgWzX0sRCUq8FfRFYx5C6pDlY6o/gZvLXDHfTOiNkcw==",
                    SecurityStamp = "HGYPVVB4WEASU6HMMB7P5TSFF6SDCAZO",
                    ConcurrencyStamp = "890f33b5-6bb6-48eb-b26a-17636366c52e",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    NotificationStatus = true
                }
            );
        }
    }
}
