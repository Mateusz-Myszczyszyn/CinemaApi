using CinemaApi.Dtos;
using CinemaApi.Entities;

namespace CinemaApi.Services
{
    public interface IAddressService
    {
        List<AddressDto> GetAll(int cinemaId);
        AddressDto GetById(int cinemaId, int addressId);
        int Create(int cinemaId, CreateAddressDto dto);
        void DeleteById(int cinemaId, int addressId);
        void DeleteAll(int cinemaId);
        void Update(int cinemaId, int addressId, CreateAddressDto dto);
    }
}