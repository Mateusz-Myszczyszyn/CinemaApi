using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Dtos.Pagination;
using CinemaApi.Entities;

namespace CinemaApi.Services
{
    public interface IAddressService
    {
        PagedResult<AddressDto> GetAll(int cinemaId,AddressQuery query);
        AddressDto GetById(int cinemaId, int addressId);
        int Create(int cinemaId, CreateAddressDto dto);
        void DeleteById(int cinemaId, int addressId);
        void DeleteAll(int cinemaId);
        void Update(int cinemaId, int addressId, CreateAddressDto dto);
    }
}