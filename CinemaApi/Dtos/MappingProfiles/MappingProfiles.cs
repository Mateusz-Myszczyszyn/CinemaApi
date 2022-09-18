using AutoMapper;
using CinemaApi.Dtos.CinemaDtos;
using CinemaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCinemaDto, Cinema>();

        }
    }
}
