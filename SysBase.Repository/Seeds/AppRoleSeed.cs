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
    public class AppRoleSeed : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole
                {
                    Id = "89742663-4322-414e-8fa4-749bbe385b6b",
                    MenuPermissions = "[{\"MenuId\":4,\"ControllerName\":\"User\",\"List\":true,\"Add\":false,\"Edit\":false,\"Delete\":false,\"Export\":false},{\"MenuId\":25,\"ControllerName\":\"Role\",\"List\":false,\"Add\":false,\"Edit\":false,\"Delete\":false,\"Export\":false},{\"MenuId\":28,\"ControllerName\":\"MenuAuthorityType\",\"List\":false,\"Add\":false,\"Edit\":false,\"Delete\":false,\"Export\":false},{\"MenuId\":7,\"ControllerName\":\"Config\",\"List\":false,\"Add\":false,\"Edit\":false,\"Delete\":false,\"Export\":false},{\"MenuId\":9,\"ControllerName\":\"Language\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":13,\"ControllerName\":\"PanelLanguage\",\"List\":false,\"Add\":false,\"Edit\":false,\"Delete\":false,\"Export\":false},{\"MenuId\":17,\"ControllerName\":\"Notification\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":20,\"ControllerName\":\"Page\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true}]",
                    Status = true,
                    CreatedDate = DateTime.Parse("2023-07-20 17:28:27"),
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "558182b7-dbce-4b2e-97db-27a2a1c2b0be"
                },
                new AppRole
                {
                    Id = "89da1481-68a8-44a8-9b21-61187635a1cb",
                    MenuPermissions = "[{\"MenuId\":4,\"ControllerName\":\"User\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":25,\"ControllerName\":\"Role\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":28,\"ControllerName\":\"MenuAuthorityType\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":7,\"ControllerName\":\"Config\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":9,\"ControllerName\":\"Language\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":13,\"ControllerName\":\"PanelLanguage\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":17,\"ControllerName\":\"Notification\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true},{\"MenuId\":20,\"ControllerName\":\"Page\",\"List\":true,\"Add\":true,\"Edit\":true,\"Delete\":true,\"Export\":true}]",
                    Status = true,
                    CreatedDate = DateTime.Parse("2023-07-20 17:28:27"),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = "d1e99c6f-cd2c-4855-b881-5b1c0eadb74b"
                }
            );
        }
    }
}
