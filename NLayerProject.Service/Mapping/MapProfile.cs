using AutoMapper;
using NLayerProject.Core.DTOs;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            //entityden dtoya çeviriyoruz
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();

            //dto'dan entity'e çevirmek istersem;
            CreateMap<TeamDto, Team>();
        }
    }
}
