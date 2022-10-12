using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;

namespace CinemaApi.Services
{
    public interface IUserAccountService
    {
        string LoginUser(LoginUserDto dto);
        void RegisterUser(RegisterUserDto dto);
    }
}