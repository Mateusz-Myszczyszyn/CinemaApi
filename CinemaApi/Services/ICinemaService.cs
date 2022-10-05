using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Entities;

namespace CinemaApi.Services
{
    public interface ICinemaService
    {
        void Delete(int id);
        List<CinemaDto> GetAll();
        CinemaDto GetById(int id);
        int Create(CreateCinemaDto dto);
        void Update(CreateCinemaDto dto, int id);
    }
}