using CinemaApi.Dtos;

namespace CinemaApi.Services
{
    public interface IHallSeatService
    {
        int Create(int cinemaHallId, CreateHallSeatsDto dto);
        void DeleteAll(int cinemaHallId);
        void DeleteById(int cinemaHallId, int hallSeatId);
        List<HallSeatsDto> GetAll(int cinemaHallId);
        HallSeatsDto GetById(int cinemaHallId, int hallSeatId);
        void Update(int cinemaHallId, int hallSeatId, CreateHallSeatsDto dto);
    }
}