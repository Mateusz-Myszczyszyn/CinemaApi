using AutoMapper;
using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Dtos.Pagination;
using CinemaApi.Entities;
using CinemaApi.Exceptions;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CinemaApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public MovieService(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PagedResult<MovieDto> GetAll(MovieQuery query)
        {
            var basicQuery = _context.Movies
            .Where(c => query.SearchPhrase == null || (c.Title.ToLower().Contains(query.SearchPhrase.ToLower()))
                || (c.Description.ToLower().Contains(query.SearchPhrase.ToLower())));

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Movie, object>>>
                {
                    {nameof(Movie.Premiere), r=>r.Premiere }
                };

                var selectedColumn = columnsSelector[query.SortBy];

                basicQuery = query.SortDirection == SortDirection.ASC
                    ? basicQuery.OrderBy(selectedColumn)
                    : basicQuery.OrderByDescending(selectedColumn);
            }

            var Movies = basicQuery
                .Skip(query.PageItems * (query.PageNumber - 1))
                .Take(query.PageItems)
                .ToList();

            var totalCount = basicQuery.Count();

            var MoviesDto = _mapper.Map<List<MovieDto>>(Movies);

            var result = new PagedResult<MovieDto>(MoviesDto, totalCount, query.PageItems, query.PageNumber);

            return result;
        }

        public MovieDto GetById(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == movieId);
            var movieMap = _mapper.Map<MovieDto>(movie);
            
            if (movieMap is null) throw new NotFoundException("Movie not found");

            return movieMap;
        }

        public int Create(CreateMovieDto dto)
        {
            var createdMovie = _mapper.Map<Movie>(dto);
            if (createdMovie != null)
            {
                _context.Movies.Add(createdMovie);
                _context.SaveChanges();
                return createdMovie.Id;
            }
            return 0;
        }

        public void DeleteAll()
        {
            var movies = _context.Movies.ToList();

            if (!movies.Any()) throw new NotFoundException("Movies not found");

            _context.RemoveRange(movies);
            _context.SaveChanges();
        }

        public void DeleteById(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            
            if (movie is null) throw new NotFoundException("Movie not found");

            _context.Remove(movie);
            _context.SaveChanges();
        }

        public void Update(int movieId, CreateMovieDto dto)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);

            if (movie is null) throw new NotFoundException("Movie not found");

            movie.Title = dto.Title;
            movie.Director = dto.Director;
            movie.Description = dto.Description;
            movie.Premiere = dto.Premiere;

            _context.SaveChanges();
        }

    }
}
