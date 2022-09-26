using AutoMapper;
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

            CreateMap<Address, AddressDto>();

            CreateMap<AddressDto, Address>();

            CreateMap<CreateAddressDto,Address>();

            CreateMap<Cinema,CinemaDto>();

            CreateMap<CinemaDto, Cinema>();
        }
    }
}
