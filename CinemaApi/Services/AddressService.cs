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
        public List<AddressDto> GetAll(int cinemaId)///
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
