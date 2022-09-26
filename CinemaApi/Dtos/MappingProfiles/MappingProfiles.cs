using AutoMapper;
using CinemaApi.Entities;

namespace CinemaApi.Dtos.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCinemaDto, Cinema>();

            CreateMap<Address, AddressDto>();

            //CreateMap<AddressDto, Address>();

            CreateMap<CreateAddressDto,Address>();

            CreateMap<Cinema, CinemaDto>();

            CreateMap<Movie, MovieDto>();
                
            CreateMap<CreateMovieDto, Movie>();
                
            
        }
    }
}
