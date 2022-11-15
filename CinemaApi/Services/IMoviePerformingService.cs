using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Dtos.Pagination;
using CinemaApi.Entities;

namespace CinemaApi.Services
{
    public interface IMoviePerformingService
    {
        PagedResult<MoviePerformingDto> GetAll(MoviePerformingQuery query);
        MoviePerformingDto GetById(int moviePerfId);
        int Create(CreateMoviePerformanceDto dto);
        void DeleteById(int moviePerfId);
        void Update(int moviePerfId, CreateMoviePerformanceDto dto);
    }
}