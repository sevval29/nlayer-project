using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Repository.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            //Fluent API Ayarlamaları
            builder.ToTable("UserProfile");  //buraya bir şey yazmadığımızda AppDbContext içerisindekini isim olarak alıcak

            builder.HasKey(up => up.Id); // Primary key belirleme( Uygun formattayse gerek yok.)
            builder.Property(t => t.Id)
               .UseIdentityColumn(); // Otomatik artış için

        }
    }
}
