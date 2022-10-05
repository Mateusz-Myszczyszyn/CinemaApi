using AutoMapper;
using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Entities;
using CinemaApi.Exceptions;

namespace CinemaApi.Services
{
    public class HallSeatService : IHallSeatService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public HallSeatService(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<HallSeatsDto> GetAll(int cinemaHallId)
        {
            var cinemaHallSeats = GetCinemaHallById(cinemaHallId).HallSeats.ToList();

            var HallSeats = _mapper.Map<List<HallSeatsDto>>(cinemaHallSeats);

            if (!HallSeats.Any()) throw new NotFoundException($"HallSeats for this cinemaHall(id = {cinemaHallId} do not exist");

            return HallSeats;
        }

        public HallSeatsDto GetById(int cinemaHallId, int hallSeatId)
        {
            var cinemaHallSeat = GetCinemaHallById(cinemaHallId).HallSeats.FirstOrDefault(h => h.Id == hallSeatId);

            var hallSeat = _mapper.Map<HallSeatsDto>(cinemaHallSeat);

            if (hallSeat is null) throw new NotFoundException($"Specific seat( id = {hallSeatId}) not found");

            return hallSeat;
        }

        public void DeleteById(int cinemaHallId, int hallSeatId)
        {
            var cinemaHall = GetCinemaHallById(cinemaHallId);

            var hallSeatToDelete = cinemaHall.HallSeats.FirstOrDefault(h => h.Id == hallSeatId);

            if (hallSeatToDelete is null) throw new NotFoundException($"Specific seat( id = {hallSeatId}) not found");

            _context.HallSeats.Remove(hallSeatToDelete);
            _context.SaveChanges();
        }

        public void DeleteAll(int cinemaHallId)
        {
            var cinemaHall = GetCinemaHallById(cinemaHallId);

            var seatsToDelete = cinemaHall.HallSeats.ToList();

            if (!seatsToDelete.Any()) throw new NotFoundException($"HallSeats for this cinemaHall(id = {cinemaHallId} do not exist");

            _context.RemoveRange(seatsToDelete);
            _context.SaveChanges();

        }

        public int Create(int cinemaHallId, CreateHallSeatsDto dto)
        {
            var cinemaHall = GetCinemaHallById(cinemaHallId);

            var newHallSeat = _mapper.Map<HallSeats>(dto);

            newHallSeat.CinemaHallId = cinemaHall.Id;

            if (newHallSeat is null) throw new BadRequestException("Something went wrong with creating seat");

            _context.HallSeats.Add(newHallSeat);
            _context.SaveChanges();

            return newHallSeat.Id;
        }

        public void Update(int cinemaHallId, int hallSeatId, CreateHallSeatsDto dto)
        {
            var cinemaHallSeat = GetCinemaHallById(cinemaHallId);

            var mapSeat = _mapper.Map<HallSeats>(dto);

            var SeatToUpdate = cinemaHallSeat.HallSeats.FirstOrDefault(s => s.Id == hallSeatId);

            if (SeatToUpdate is null) throw new NotFoundException($"HallSeats for this cinemaHall(id = {cinemaHallId} does not exist");

            SeatToUpdate.Row = dto.Row;
            SeatToUpdate.Seat = dto.Seat;

            _context.SaveChanges();

        }

        private CinemaHall GetCinemaHallById(int cinemaHallId)
        {
            var cinemaHall = _context.CinemaHalls.FirstOrDefault(c => c.Id == cinemaHallId);

            if (cinemaHall is null) throw new NotFoundException($"CinemaHall with this Id = {cinemaHallId} does not exist");

            return cinemaHall;
        }
    }
}
