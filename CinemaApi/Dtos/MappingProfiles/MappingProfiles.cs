using AutoMapper;
using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
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

            CreateMap<CinemaHall, CinemaHallDto>();
                

            CreateMap<CreateCinemaHallDto, CinemaHall>();

            CreateMap<HallSeats,HallSeatsDto>();

            CreateMap<CreateHallSeatsDto,HallSeats>();

            CreateMap<MoviePerforming, MoviePerformingDto>()
                .ForMember(m=>m.MovieId, c=>c.MapFrom(c=>c.MovieId))
                .ForMember(m => m.Id, c => c.MapFrom(c => c.Id))
                .ForMember(m => m.CinemaHallId, c => c.MapFrom(c => c.CinemaHallId));

            CreateMap<CreateMoviePerformanceDto, MoviePerforming>()
                .ForMember(c => c.CinemaHallId, c => c.MapFrom(c => c.CinemaHallId))
                .ForMember(c => c.MovieId, c => c.MapFrom(c => c.MovieId));
        }
    }
}
