using CinemaApi.Dtos;
using CinemaApi.Entities;

namespace CinemaApi.Services
{
    public interface IAddressService
    {
        List<AddressDto> GetAll(int cinemaId);
    }
}