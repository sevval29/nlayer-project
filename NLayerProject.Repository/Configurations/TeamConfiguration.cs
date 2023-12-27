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
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            //Fluent API ayarlamaları

            //Primary key ayarlaması

            builder.HasKey(x => x.Id);

            //Primary key otomatik olarak 1'er 1'er artsın

            builder.Property(t => t.Id).UseIdentityColumn();// Otomatik artış için


            // TeamName alanı için maksimum uzunluğu belirleme ve zorunlu hale getirme
            builder.Property(t => t.TeamName)
                   .HasMaxLength(100)
                   .IsRequired();


            // Tablo adı belirleme (Opsiyonel)
            builder.ToTable("Teams");
        }
    }
}
