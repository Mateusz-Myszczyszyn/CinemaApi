using AutoMapper;
using CinemaApi.Entities;

namespace CinemaApi.Dtos.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCinemaDto, Cinema>();

            CreateMap<Address, AddressDto>()
                .ForMember(a=>a.CinemaName,a=>a.MapFrom(a=>a.Cinema.Name));

            CreateMap<Address, NoIdAddressDto>();
            //CreateMap<AddressDto, Address>();

            CreateMap<CreateAddressDto,Address>();

            CreateMap<Cinema, CinemaDto>();

            CreateMap<CinemaDto, Cinema>();

            CreateMap<Movie, MovieDto>();
                
            CreateMap<CreateMovieDto, Movie>();

            CreateMap<CinemaHall, CinemaHallDto>()
                .ForMember(c=>c.Address,c=>c.MapFrom(a=>a.Address));

            CreateMap<CreateCinemaHallDto, CinemaHall>();
            
        }
    }
}
