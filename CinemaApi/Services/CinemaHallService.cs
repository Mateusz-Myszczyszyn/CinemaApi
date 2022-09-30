using AutoMapper;
using CinemaApi.Dtos;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CinemaApi.Services
{
    public class CinemaHallService : ICinemaHallService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public CinemaHallService(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CinemaHallDto> GetAll(int addressId)
        {
            var address = GetAddressById(addressId);

            var cinemaHalls = _mapper.Map<List<CinemaHallDto>>(address.CinemaHalls);

            if (!cinemaHalls.Any()) throw new NotFoundException("There are not halls for this cinema");

            return cinemaHalls;
        }

        public CinemaHallDto GetById(int addressId, int cinemaHallId)
        {
            var address = GetAddressById(addressId);

            var cinemaHalls = _mapper.Map<List<CinemaHallDto>>(address.CinemaHalls);

            var specificCinemaHall = cinemaHalls.FirstOrDefault(ch => ch.Id == cinemaHallId);

            if (specificCinemaHall is null) throw new NotFoundException("There is not hall for this cinema");

            return specificCinemaHall;
        }

        public int Create(int addressId, CreateCinemaHallDto dto)
        {
            var address = GetAddressById(addressId);

            var newCinemaHall = _mapper.Map<CinemaHall>(dto);

            newCinemaHall.AddressId = address.Id;

            if (newCinemaHall is null) throw new BadRequestException("Something went wrong with sending data");

            _context.CinemaHalls.Add(newCinemaHall);
            _context.SaveChanges();

            return newCinemaHall.Id;
        }

        public void DeleteById(int addressId, int cinemaHallId)
        {
            var address= GetAddressById(addressId);

            var cinemaHallToDelete = address.CinemaHalls.FirstOrDefault(ch => ch.Id == cinemaHallId);

            if (cinemaHallToDelete is null) throw new NotFoundException($"The cinemahall{cinemaHallId} u want to delete does not exist");

            _context.CinemaHalls.Remove(cinemaHallToDelete);
            _context.SaveChanges();
        }
        private Address GetAddressById(int addressId)
        {
            var address = _context.Addresses
                .Include(a => a.CinemaHalls)
                .Include(a=>a.Cinema)
                .FirstOrDefault(a => a.Id == addressId);

            if (address is null) throw new NotFoundException("Specific address not found");

            return address;
        }
    }
}
