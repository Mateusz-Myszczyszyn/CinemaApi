using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;

namespace CinemaApi.Services
{
    public interface IScreenPlayService
    {
        int Create(CreateScreenPlayDto dto);
        void DeleteById(int screenPlayId);
        List<ScreenPlayDto> GetAll();
        ScreenPlayDto GetById(int screenPlayId);
        void Update(int screenPlayId, CreateScreenPlayDto dto);
        //void DeleteAll();
    }
}