using CinemaApi.Dtos;
using CinemaApi.Entities;

namespace CinemaApi.Services
{
    public interface IAddressService
    {
        List<AddressDto> GetAll(int cinemaId);
        AddressDto GetById(int cinemaId, int addressId);
        int Create(int cinemaId, CreateAddressDto dto);
    }
}