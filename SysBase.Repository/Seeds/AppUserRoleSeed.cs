using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SysBase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Repository.Seeds
{
    public class AppUserRoleSeed : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(
                new AppUserRole
                {
                    UserId = "8ae560eb-41bf-4254-ad04-b8272ea2b1e0",
                    RoleId = "89da1481-68a8-44a8-9b21-61187635a1cb"
                },
                new AppUserRole
                {
                    UserId = "e6d7e0f3-ba29-422a-8e53-97bd03008bce",
                    RoleId = "89da1481-68a8-44a8-9b21-61187635a1cb"
                }
            );
        }
    }
}
