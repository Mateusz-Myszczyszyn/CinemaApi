using CinemaApi.Entities;

namespace CinemaApi.Services
{
    public interface ICinemaService
    {
        void Delete(int id);
        List<Cinema> GetAll();
        Cinema GetById(int id);
    }
}