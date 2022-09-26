using AutoMapper;
using CinemaApi.Dtos;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public CinemaService(CinemaDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public  List<CinemaDto> GetAll()
        {
            var cinemas = _context.Cinemas.ToList();

            var mapCinema = _mapper.Map<List<CinemaDto>>(cinemas);

            if (!mapCinema.Any()) throw new NotFoundException("Cinemas not found");

            return mapCinema;
        }

        public CinemaDto GetById(int id)
        {
            var cinema =  _context.Cinemas.FirstOrDefault(c => c.Id == id);

            var mapCinema = _mapper.Map<CinemaDto>(cinema);

            if (mapCinema is null) throw new NotFoundException("Specific cinema not found");

            return mapCinema;
        }

        public void Delete(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if (cinema is null) throw new NotFoundException("Specific cinema not found");

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
        }

        public int Create(CreateCinemaDto dto)
        {
            var createdCinema = _mapper.Map<Cinema>(dto);

            if(createdCinema != null)
            {
                _context.Cinemas.Add(createdCinema);
                _context.SaveChanges();
                return createdCinema.Id;
            }

            return 0;
            
        }

        public void Update(CreateCinemaDto dto, int id)
        {
            var updatedCinema = _mapper.Map<Cinema>(dto);
            var cinemaToUpdate = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if (cinemaToUpdate is null) throw new NotFoundException("Specific cinema not found");

            cinemaToUpdate.Name = updatedCinema.Name;
            cinemaToUpdate.Owner = updatedCinema.Owner;
            cinemaToUpdate.WorkersQuantity = updatedCinema.WorkersQuantity;
            _context.SaveChanges();
        }


    }
}
