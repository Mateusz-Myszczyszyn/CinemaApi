using AutoMapper;
using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class ScreenPlayService : IScreenPlayService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public ScreenPlayService(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ScreenPlayDto> GetAll()
        {
            var screenPlays = _context.ScreenPlays
                .Include(c => c.MoviePerforming).ToList();

            var mappedScrPlays = _mapper.Map<List<ScreenPlayDto>>(screenPlays);

            if (!mappedScrPlays.Any()) throw new NotFoundException("Playing hours for movies do not exist");

            return mappedScrPlays;
        }

        public ScreenPlayDto GetById(int screenPlayId)
        {
            var screenPlay = _context.ScreenPlays.Include(c => c.MoviePerforming).FirstOrDefault(c => c.Id == screenPlayId);

            var mappedScrPlay = _mapper.Map<ScreenPlayDto>(screenPlay);

            if (mappedScrPlay is null) throw new NotFoundException($"Playing hour for this screening id = {screenPlayId} does not exist");

            return mappedScrPlay;
        }

        public int Create(CreateScreenPlayDto dto)
        {
            var createdScreenPlay = _mapper.Map<ScreenPlay>(dto);

            var checkIfMoviePerf = _context.MoviePerformings.FirstOrDefault(c=>c.Id == createdScreenPlay.MoviePerformingId);

            if (createdScreenPlay is null) throw new BadRequestException("Something went wrong with creating record, check requirements");

            if (checkIfMoviePerf is null) throw new NotFoundException($"Movie performing with id = {createdScreenPlay.MoviePerformingId} does not exist so you can't associate screen play with it");
            
            _context.ScreenPlays.Add(createdScreenPlay);
            _context.SaveChanges();
            return createdScreenPlay.Id;
        }

        public void DeleteById(int screenPlayId)
        {
            var scrPlayToDelete = _context.ScreenPlays.FirstOrDefault(c => c.Id == screenPlayId);

            if (scrPlayToDelete is null) throw new NotFoundException("Playing hours for this screening does not exist");

            _context.Remove(scrPlayToDelete);
            _context.SaveChanges();
        }

       /* public void DeleteAll()
        {
            var scrPlayToDelete = _context.ScreenPlays.ToList();

            if (!scrPlayToDelete.Any()) throw new NotFoundException("Playing hours do not exist");

            _context.RemoveRange(scrPlayToDelete);
            _context.SaveChanges();
        }*/

        public void Update(int screenPlayId, CreateScreenPlayDto dto)
        {
            var mappedScrPlay = _mapper.Map<ScreenPlay>(dto);

            var toUpdate = _context.ScreenPlays.FirstOrDefault(c => c.Id == screenPlayId);

            var checkIfMoviePerf = _context.MoviePerformings.FirstOrDefault(c => c.Id == mappedScrPlay.MoviePerformingId);

            if (toUpdate is null) throw new NotFoundException("Screen play you want to update does not exist");

            if (checkIfMoviePerf is null) throw new NotFoundException($"Movie performing with id = {mappedScrPlay.MoviePerformingId} does not exist so you can't associate screen play with it");

            toUpdate.ShowTime = mappedScrPlay.ShowTime;
            toUpdate.MoviePerformingId = mappedScrPlay.MoviePerformingId;

            _context.SaveChanges();
        }
    }
}
