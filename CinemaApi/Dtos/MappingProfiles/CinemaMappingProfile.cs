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
    public class CinemaMappingProfile : Profile
    {
        public CinemaMappingProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>()
                .ForMember(r => r.Addresses, c => c.MapFrom(dto => new Address()
                { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));
                
        }
    }
}
