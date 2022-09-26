using AutoMapper;
using CinemaApi.Dtos;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Services
{
    public class AddressService : IAddressService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public AddressService(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<AddressDto> GetAll(int cinemaId)
        {
            var cinema = GetCinemaById(cinemaId);
            
            var AddressesDto = _mapper.Map<List<AddressDto>>(cinema.Addresses);

            if (!AddressesDto.Any()) throw new NotFoundException($"Addresses for this cinema({cinemaId}) do not exist");

            return AddressesDto;

        }

        public AddressDto GetById(int cinemaId, int addressId)
        {
            var cinema = GetCinemaById(cinemaId);

            var AddressesDto = _mapper.Map<List<AddressDto>>(cinema.Addresses);

            var specificAddress = AddressesDto.FirstOrDefault(c => c.Id == addressId);

            if (specificAddress is null) throw new NotFoundException($"Specific address for this cinema({cinemaId}) cannot be found");

            return specificAddress;
        }

        public int Create(int cinemaId,CreateAddressDto dto)
        {
            var cinema = GetCinemaById(cinemaId);

            var newAddress = _mapper.Map<Address>(dto);

            newAddress.CinemaId = cinema.Id;

            if (newAddress is null) throw new BadRequestException("Something went wrong with creating new address");

            _context.Addresses.Add(newAddress);
            _context.SaveChanges();

            return newAddress.Id;

        }

        public void DeleteById(int cinemaId,int addressId)
        {
            var cinema = GetCinemaById(cinemaId);

            var addressToDelete = cinema.Addresses.FirstOrDefault(d => d.Id == addressId);

            if (addressToDelete is null) throw new NotFoundException($"Specific address({addressId}) not found");

            _context.Addresses.Remove(addressToDelete);
            _context.SaveChanges();
        }

        public void DeleteAll(int cinemaId)
        {
            var cinemaAddresses = GetCinemaById(cinemaId).Addresses.ToList();

            if(!cinemaAddresses.Any()) throw new NotFoundException($"Addresses for this cinema({cinemaId}) do not exist");

            _context.RemoveRange(cinemaAddresses);
            _context.SaveChanges();
        }

        public void Update(int cinemaId, int addressId, CreateAddressDto dto)
        {
            var cinema = GetCinemaById(cinemaId);

            var mapAddress = _mapper.Map<Address>(dto);

            var addressToUpdate = cinema.Addresses.FirstOrDefault(a => a.Id == addressId);

            if (addressToUpdate is null) throw new NotFoundException($"Specific address({addressId}) not found");

            addressToUpdate.City = dto.City;
            addressToUpdate.Street = dto.Street;
            addressToUpdate.PostalCode = dto.PostalCode;

            _context.SaveChanges();

        }

        private Cinema GetCinemaById(int cinemaId)
        {
            var cinema = _context.Cinemas
                .Include(a => a.Addresses)
                .FirstOrDefault(a => a.Id == cinemaId);

            if (cinema is null) throw new NotFoundException("Specific cinema not found");

            return cinema;
        }

        
    }
}
