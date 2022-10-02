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

        public List<CinemaHallDto> GetAll()
        {
            var premapCinemaHalls = _context.CinemaHalls.ToList();

            var cinemaHalls = _mapper.Map<List<CinemaHallDto>>(premapCinemaHalls);

            if (!cinemaHalls.Any()) throw new NotFoundException("CinemaHalls not found");

            return cinemaHalls;
        }

        public CinemaHallDto GetById(int cinemaHallId)
        {

            var premapCinemaHall = _context.CinemaHalls.FirstOrDefault(c => c.Id == cinemaHallId);

            var cinemaHall = _mapper.Map<CinemaHallDto>(premapCinemaHall);

            if (cinemaHall is null) throw new NotFoundException("Specific hall does not exist");

            return cinemaHall;
        }

        public int Create(CreateCinemaHallDto dto)
        {
            var newCinemaHall = _mapper.Map<CinemaHall>(dto);

            if (newCinemaHall is null) throw new BadRequestException("Something went wrong with sending data");

            _context.CinemaHalls.Add(newCinemaHall);
            _context.SaveChanges();

            return newCinemaHall.Id;
        }

        public void DeleteById(int cinemaHallId)
        {
            var cinemaHallToDelete = _context.CinemaHalls.FirstOrDefault(c => c.Id == cinemaHallId);

            if (cinemaHallToDelete is null) throw new NotFoundException($"The cinemahall{cinemaHallId} u want to delete does not exist or it was deleted");

            _context.CinemaHalls.Remove(cinemaHallToDelete);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            var cinemaHallsToDelete = _context.CinemaHalls.ToList();

            if (!cinemaHallsToDelete.Any()) throw new NotFoundException($"The cinemahalls  u want to delete do not exist or they were deleted");

            _context.CinemaHalls.RemoveRange(cinemaHallsToDelete);
            _context.SaveChanges();
        }
        
    }
}
