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
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, UserName = "john_doe", Email = "john@example.com", Password = "password123", TeamId = 1 ,CreatedDate=DateTime.Now},
                new User { Id = 2, UserName = "jane_doe", Email = "jane@example.com", Password = "password456", TeamId = 2, CreatedDate = DateTime.Now },
                new User { Id = 3, UserName = "bob_smith", Email = "bob@example.com", Password = "password789", TeamId = 1, CreatedDate = DateTime.Now }
           
            );
        }
    }
}
