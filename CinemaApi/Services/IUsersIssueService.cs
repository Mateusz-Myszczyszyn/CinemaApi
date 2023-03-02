using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Entities;

namespace CinemaApi.Services
{
    public interface IUsersIssueService
    {
        void Create(CreateUserIssueDto dto);
        void DeleteAll();
        void DeleteById(int issueId);
        List<UsersIssues> GetAll();
        UsersIssues GetById(int issueId);
    }
}