using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Repository.Seeds
{
    public class UserProfileSeedConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasData(
                new UserProfile { Id = 1, FirstName = "John", LastName = "Doe", NickName = "JD", UserId = 1 },
                new UserProfile { Id = 2, FirstName = "Jane", LastName = "Doe", NickName = "Jane", UserId = 2 },
                new UserProfile { Id = 3, FirstName = "Bob", LastName = "Smith", NickName = "Bob", UserId = 3 }
            // Diğer seed verileri buraya eklenebilir.
            );
        }
    }
}
