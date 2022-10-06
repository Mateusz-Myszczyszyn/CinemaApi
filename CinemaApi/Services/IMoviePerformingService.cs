using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Entities;

namespace CinemaApi.Services
{
    public interface IMoviePerformingService
    {
        List<MoviePerformingDto> GetAll();
        MoviePerformingDto GetById(int moviePerfId);
        int Create(CreateMoviePerformanceDto dto);
        void DeleteById(int moviePerfId);
        void Update(int moviePerfId, CreateMoviePerformanceDto dto);
    }
}