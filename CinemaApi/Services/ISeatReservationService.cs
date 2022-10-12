using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;

namespace CinemaApi.Services
{
    public interface ISeatReservationService
    {
        int Create(CreateSeatReservationDto dto);
        void DeleteById(int seatReservationId);
        List<SeatReservationDto> GetAll();
        SeatReservationDto GetById(int seatReservationId);
        void Update(int seatReservationId, UpdateSeatReservationDto dto);
    }
}