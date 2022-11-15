using AutoMapper;
using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Dtos.Pagination;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class MoviePerformingService : IMoviePerformingService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public MoviePerformingService(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PagedResult<MoviePerformingDto> GetAll(MoviePerformingQuery query)
        {
            var basicQuery = _context.MoviePerformings
                .Include(c=>c.Movie)
                .Include(c=>c.CinemaHall)
                .Where(c => query.SearchPhrase == null || (c.CinemaHall.HallName.ToLower().Contains(query.SearchPhrase.ToLower()))
                || (c.Movie.Title.ToLower().Contains(query.SearchPhrase.ToLower())));

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<MoviePerforming, object>>>
                {
                    {nameof(MoviePerforming.Movie.Title), r=>r.Movie.Title},
                    {nameof(MoviePerforming.CinemaHall.HallName), r=>r.CinemaHall.HallName },
                };

                var selectedColumn = columnsSelector[query.SortBy];

                basicQuery = query.SortDirection == SortDirection.ASC
                    ? basicQuery.OrderBy(selectedColumn)
                    : basicQuery.OrderByDescending(selectedColumn);
            }

            var moviePerformings = basicQuery
                .Skip(query.PageItems * (query.PageNumber - 1))
                .Take(query.PageItems)
                .ToList();

            var totalCount = basicQuery.Count();

            var moviePerformingsDtos = _mapper.Map<List<MoviePerformingDto>>(moviePerformings);

            var result = new PagedResult<MoviePerformingDto>(moviePerformingsDtos, totalCount, query.PageItems, query.PageNumber);

            return result;
        }

        public MoviePerformingDto GetById(int moviePerfId)
        {
            var movieperf = _context.MoviePerformings.FirstOrDefault(c => c.Id == moviePerfId);

            var movieperfMapped = _mapper.Map<MoviePerformingDto>(movieperf);

            if (movieperfMapped is null) throw new NotFoundException($"Cannot find movieperforming property with this parameter( id = {moviePerfId} )");

            return movieperfMapped;
        }

        public int Create(CreateMoviePerformanceDto dto)
        {
            var createMoviePref = _mapper.Map<MoviePerforming>(dto);

            var checkIfMovie = _context.Movies.FirstOrDefault(c => c.Id == createMoviePref.MovieId);
            var checkIfCinemaHall = _context.CinemaHalls.FirstOrDefault(c => c.Id == createMoviePref.CinemaHallId);

            if (checkIfMovie is null) throw new NotFoundException($"The movie with id({createMoviePref.MovieId}) does not exist");

            if (checkIfCinemaHall is null) throw new NotFoundException($"The cinema hall with id({createMoviePref.CinemaHallId}) does not exist");

            if (createMoviePref is null) throw new BadRequestException("Something went wrong with creating data, check validators and try again");

            _context.MoviePerformings.Add(createMoviePref);
            _context.SaveChanges();

            return createMoviePref.Id;
        }

        public void DeleteById(int moviePerfId)
        {
            var moviePerf = _context.MoviePerformings.FirstOrDefault(c => c.Id == moviePerfId);

            if (moviePerf is null) throw new NotFoundException($"MoviePerformence record with id = {moviePerfId} does not exist");

            _context.MoviePerformings.Remove(moviePerf);
            _context.SaveChanges();
        }
        
        public void Update(int moviePerfId,CreateMoviePerformanceDto dto)
        {
            var mapped = _mapper.Map<MoviePerforming>(dto);

            var MoviePerfToUpdate = _context.MoviePerformings.FirstOrDefault(c => c.Id == moviePerfId);

            var checkifMovie = _context.Movies.FirstOrDefault(c => c.Id == mapped.MovieId);
            var checkifCinemaHall = _context.CinemaHalls.FirstOrDefault(c => c.Id == mapped.CinemaHallId);

            if (MoviePerfToUpdate is null) throw new NotFoundException($"MoviePerformence record with id = {moviePerfId} does not exist");

            if (checkifMovie is null) throw new NotFoundException($"The movie with id = {mapped.MovieId} does not exist");

            if (checkifCinemaHall is null) throw new NotFoundException($"The cinema hall with id= {mapped.CinemaHallId} does not exist");

            MoviePerfToUpdate.MovieId = mapped.MovieId;
            MoviePerfToUpdate.CinemaHallId = mapped.CinemaHallId;

            _context.SaveChanges();
        }
        
    }
}
