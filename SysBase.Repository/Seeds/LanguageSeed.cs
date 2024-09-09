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
    internal class LanguageSeed : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasData(
                new Language { Id = 1, Name = "Türkçe", Code = "tr", Image = "tr.png", Status = true, AdminStatus = true, CreatedDate = DateTime.Now },
                new Language { Id = 2, Name = "English", Code = "en", Image = "en.png", Status = true, AdminStatus = true, CreatedDate = DateTime.Now }
            );
        }
    }
}
