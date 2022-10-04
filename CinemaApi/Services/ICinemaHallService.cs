using CinemaApi.Dtos;

namespace CinemaApi.Services
{
    public interface ICinemaHallService
    {
        List<CinemaHallDto> GetAll(int addressId);
        CinemaHallDto GetById(int addressId,int cinemaHallId);
        int Create(int addressId,CreateCinemaHallDto dto);
        void DeleteById(int addressId,int cinemaHallId);
        void DeleteAll(int addressId);
        void Update(int addressId,int cinemaHallId, CreateCinemaHallDto dto);
    }
}