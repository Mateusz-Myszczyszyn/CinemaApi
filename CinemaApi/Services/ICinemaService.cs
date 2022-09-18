using CinemaApi.Dtos.CinemaDtos;
using CinemaApi.Entities;

namespace CinemaApi.Services
{
    public interface ICinemaService
    {
        void Delete(int id);
        List<Cinema> GetAll();
        Cinema GetById(int id);
        int Create(CreateCinemaDto dto);
        void Update(CreateCinemaDto dto, int id);
    }
}