using CinemaApi.Dtos;

namespace CinemaApi.Services
{
    public interface ICinemaHallService
    {
        List<CinemaHallDto> GetAll(int cinemaId);
        CinemaHallDto GetById(int cinemaId, int cinemaHallId);
        int Create(int cinemaId, CreateCinemaHallDto dto);
    }
}