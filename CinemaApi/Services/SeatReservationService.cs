using AutoMapper;
using CinemaApi.Authorization;
using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class SeatReservationService : ISeatReservationService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContext;
        private readonly IAuthorizationService _authService;
        private readonly ILogger<SeatReservationService> _logger;

        public SeatReservationService(CinemaDbContext context, IMapper mapper, IUserContextService userContext,IAuthorizationService authService
            ,ILogger<SeatReservationService> logger)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
            _authService = authService;
            _logger = logger;
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

            var pegi = createReservation.ScreenPlay.MoviePerforming.Movie.PEGI;

            if(pegi == 18)
            {
                var user = _userContext.User;
                var authorizationResult = _authService.AuthorizeAsync(user, createReservation, new AgeForMovieRequirement(18)).Result;
                if (!authorizationResult.Succeeded)
                {
                    throw new ForbiddenAccessException("This user cannot make reservation for this movie because he is underaged.");
                }
                else
                {
                    _context.SeatReservations.Add(createReservation);
                    _context.SaveChanges();

                    return createReservation.Id;
                }
            }
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

        public void Update(int seatReservationId, UpdateSeatReservationDto dto)
        {
            var mapped = _mapper.Map<SeatReservation>(dto);

            var toUpdate = _context.SeatReservations.FirstOrDefault(c => c.Id == seatReservationId);


            var checkIfSeat = _context.SeatReservations.FirstOrDefault(c => c.HallSeatId == dto.HallSeatId);
            var checkIfScrPlay = _context.SeatReservations.FirstOrDefault(c => c.ScreenPlayId == dto.ScreenPlayId);

            if (toUpdate is null) throw new NotFoundException($"Reservation with id = {seatReservationId} does not exist");
            if (checkIfSeat is null) throw new NotFoundException($"Probably seat with id = {dto.HallSeatId} does not exist or is reserved");
            if (checkIfScrPlay is null) throw new NotFoundException($"There is no playing movie hours with this id = {dto.ScreenPlayId}");

            toUpdate.ScreenPlayId = mapped.ScreenPlayId;
            toUpdate.IsReserved = mapped.IsReserved;
            toUpdate.Active = mapped.Active;
            toUpdate.HallSeatId = mapped.HallSeatId;

            _context.SaveChanges();

        }

    }
}
