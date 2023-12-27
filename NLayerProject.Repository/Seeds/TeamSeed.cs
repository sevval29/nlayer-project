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
    public class TeamSeed : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                new Team { Id = 1, TeamName = "Development" , CreatedDate=DateTime.Now},
                new Team { Id = 2, TeamName = "Marketing", CreatedDate = DateTime.Now },
                new Team { Id = 3, TeamName = "Sales", CreatedDate = DateTime.Now }
            
            );
        }
    }
}
