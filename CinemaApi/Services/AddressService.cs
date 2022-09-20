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

            return AddressesDto;

        }

        private Cinema GetCinemaById(int cinemaId)
        {
            var cinema = _context.Cinemas
                .Include(a => a.Addresses)
                .FirstOrDefault(a => a.Id == cinemaId);

            if (cinema is null) throw new NotFoundException("Specific cinema not found");

            if (!cinema.Addresses.Any()) throw new NotFoundException($"Addresses for this cinema({cinemaId}) do not exist");

            return cinema;
        }
    }
}
