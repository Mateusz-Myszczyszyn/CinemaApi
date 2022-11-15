using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Dtos.Pagination;

namespace CinemaApi.Services
{
    public interface IScreenPlayService
    {
        int Create(CreateScreenPlayDto dto);
        void DeleteById(int screenPlayId);
        public PagedResult<ScreenPlayDto> GetAll(ScreenPlayQuery query);
        ScreenPlayDto GetById(int screenPlayId);
        void Update(int screenPlayId, CreateScreenPlayDto dto);

        //void DeleteAll();
    }
}