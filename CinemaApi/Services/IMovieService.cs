using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Dtos.Pagination;

namespace CinemaApi.Services
{
    public interface IMovieService
    {
        int Create(CreateMovieDto dto);
        void DeleteAll();
        void DeleteById(int movieId);
        PagedResult<MovieDto> GetAll(MovieQuery query);
        MovieDto GetById(int movieId);
        void Update(int movieId, CreateMovieDto dto);
    }
}