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

            if (!cinemaHalls.Any()) throw new NotFoundException("CinemaHalls not found");

            return cinemaHalls;
        }

        public CinemaHallDto GetById(int addressId,int cinemaHallId)
        {

            var preMapcinemaHall = GetAddressById(addressId).CinemaHalls.FirstOrDefault(c=>c.Id==cinemaHallId);

            var cinemaHall = _mapper.Map<CinemaHallDto>(preMapcinemaHall);

            if (cinemaHall is null) throw new NotFoundException("Specific hall does not exist");

            return cinemaHall;
        }

        public int Create(int addressId, CreateCinemaHallDto dto)
        {

            var premapHall = GetAddressById(addressId);

            var newCinemaHall = _mapper.Map<CinemaHall>(dto);

            if (newCinemaHall is null) throw new BadRequestException("Something went wrong with sending data");

            _context.CinemaHalls.Add(newCinemaHall);
            _context.SaveChanges();

            return newCinemaHall.Id;
        }

        public void DeleteById(int addressId,int cinemaHallId)
        {
            var cinemaHallToDelete = GetAddressById(addressId).CinemaHalls.FirstOrDefault(c=>c.Id == cinemaHallId);

            if (cinemaHallToDelete is null) throw new NotFoundException($"The cinemahall{cinemaHallId} u want to delete does not exist or it was deleted");

            _context.CinemaHalls.Remove(cinemaHallToDelete);
            _context.SaveChanges();
        }

        public void DeleteAll(int addressId)
        {
            var cinemaHallsToDelete = GetAddressById(addressId).CinemaHalls.ToList();

            if (!cinemaHallsToDelete.Any()) throw new NotFoundException($"The cinemahalls  u want to delete do not exist or they were deleted");

            _context.CinemaHalls.RemoveRange(cinemaHallsToDelete);
            _context.SaveChanges();
        }

        public void Update(int addressId,int cinemaHallId, CreateCinemaHallDto dto)
        {
            var mapHall = _mapper.Map<CinemaHall>(dto);

            var cinemaHalltoUpdate = GetAddressById(addressId).CinemaHalls.FirstOrDefault(a => a.Id == cinemaHallId);

            if(cinemaHalltoUpdate is null) throw new NotFoundException($"The cinemahall{cinemaHallId} u want to update does not exist");

            cinemaHalltoUpdate.HallName = dto.HallName;

            _context.SaveChanges();
        }

        private Address GetAddressById(int addressId)
        {
            var address = _context.Addresses.FirstOrDefault(a => a.Id == addressId);

            if (address is null) throw new NotFoundException($"Address with this id({addressId}) does not exist");

            return address;
        }
        
    }
}
