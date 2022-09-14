using CinemaApi.Entities;
using CinemaApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class CinemaService
    {
        private readonly CinemaDbContext _context;

        public CinemaService(CinemaDbContext context)
        {
            _context = context;
        }

        public List<Cinema> GetAll()
        {
            var cinemas = _context.Cinemas.ToList();

            if (!cinemas.Any()) throw new NotFoundException("Cinemas not found");

            return cinemas;
        }

        public Cinema GetById(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if (cinema is null) throw new NotFoundException("Specific cinema not found");

            return cinema;
        }

        public void Delete(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if (cinema is null) throw new NotFoundException("Specific cinema not found");

            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
        }

    }
}
