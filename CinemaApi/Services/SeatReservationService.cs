using AutoMapper;
using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class SeatReservationService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public SeatReservationService(CinemaDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SeatReservationDto> GetAll()
        {
            var reservations = _context.SeatReservations.ToList();

            var mappedReservations = _mapper.Map<List<SeatReservationDto>>(reservations);

            if (!mappedReservations.Any()) throw new NotFoundException("Reservations do not exist");

            return mappedReservations;
        }

        public SeatReservationDto GetById(int seatReservationId)
        {
            var reservation = _context.SeatReservations.FirstOrDefault(c => c.Id == seatReservationId);

            var mappedReservation = _mapper.Map<SeatReservationDto>(reservation);

            if (mappedReservation is null) throw new NotFoundException($"Reservation with id = {seatReservationId} does not exist");

            return mappedReservation;
        }

        public int Create(CreateSeatReservationDto dto)
        {
            var createReservation = _mapper.Map<SeatReservation>(dto);

            var checkIfUser = _context.Users.FirstOrDefault(c => c.Id == createReservation.UserId);
            var checkIfSeat = _context.HallSeats.FirstOrDefault(c => c.Id == createReservation.HallSeatId);
            var checkIfScreenPlay = _context.ScreenPlays.FirstOrDefault(c => c.Id == createReservation.ScreenPlayId);

            if (createReservation is null) throw new BadRequestException("Something went wrong with creating this reservation");

            if (checkIfScreenPlay is null) throw new NotFoundException($"Screen play you want to add here( with id = {createReservation.ScreenPlayId} ) does not exist");
            if (checkIfSeat is null) throw new NotFoundException($"Seats you want to add here( with id = {createReservation.HallSeatId} ) does not exist");
            if (checkIfUser is null) throw new NotFoundException($"User you want to assing here( with id = {createReservation.UserId} ) does not exist");

            _context.SeatReservations.Add(createReservation);
            _context.SaveChanges();

            return createReservation.Id;
        }

        public void DeleteById(int seatReservationId)
        {
            var reservationToDelete = _context.SeatReservations.FirstOrDefault(c => c.Id == seatReservationId);

            if (reservationToDelete is null) throw new NotFoundException($"This reservation( id = {seatReservationId} ) does not exist or was deleted ");

            _context.Remove(reservationToDelete);
            _context.SaveChanges();
        }

    }
}
