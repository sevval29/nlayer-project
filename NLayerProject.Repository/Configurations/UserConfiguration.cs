using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Fluent API Ayarlamaları
            builder.ToTable("Users"); // Tablo adın

            builder.HasKey(x => x.Id);
            // Primary key belirleme ( Uygun formattayse gerek yok.)
            builder.Property(x => x.Id)
               .UseIdentityColumn(); // Otomatik artış için

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
