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
                .ForMember(a => a.CinemaName, a => a.MapFrom(a => a.Cinema.Name));

            CreateMap<Address, NoIdAddressDto>();
            //CreateMap<AddressDto, Address>();

            CreateMap<CreateAddressDto, Address>();

            CreateMap<Cinema, CinemaDto>();

            CreateMap<CinemaDto, Cinema>();

            CreateMap<Movie, MovieDto>();

            CreateMap<CreateMovieDto, Movie>();

            CreateMap<CinemaHall, CinemaHallDto>();


            CreateMap<CreateCinemaHallDto, CinemaHall>();

            CreateMap<HallSeats, HallSeatsDto>();

            CreateMap<CreateHallSeatsDto, HallSeats>();

            CreateMap<MoviePerforming, MoviePerformingDto>();

            CreateMap<CreateMoviePerformanceDto, MoviePerforming>();

            CreateMap<ScreenPlay, ScreenPlayDto>()
                .ForMember(c=>c.ShowTime,c=>c.MapFrom(c=>c.ShowTime))
                .ForMember(c=>c.MoviePerformingDto,c=>c.MapFrom(c=>c.MoviePerforming))
                .ForMember(c=>c.Id,c=>c.MapFrom(c=>c.Id));

            CreateMap<CreateScreenPlayDto, ScreenPlay>()
                .ForMember(c => c.ShowTime, c => c.MapFrom(c => c.ShowTime))
                .ForMember(c => c.MoviePerformingId, c => c.MapFrom(c => c.MoviePerformingId));

            CreateMap<SeatReservation, SeatReservationDto>();

            CreateMap<CreateSeatReservationDto, SeatReservation>();
        }

    }
}
