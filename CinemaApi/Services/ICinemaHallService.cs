using CinemaApi.Dtos;

namespace CinemaApi.Services
{
    public interface ICinemaHallService
    {
        List<CinemaHallDto> GetAll();
        CinemaHallDto GetById(int cinemaHallId);
        int Create(CreateCinemaHallDto dto);
        void DeleteById( int cinemaHallId);
        void DeleteAll();
    }
}