using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Entities;
using CinemaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApi.Controllers
{
    [ApiController]
    [Route("api/issue")]
    public class UsersIssueController : ControllerBase
    {
        private readonly IUsersIssueService _service;

        public UsersIssueController(IUsersIssueService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Menager,Admin")]
        public ActionResult<IEnumerable<UsersIssues>> GetAll()
        {
            var allIssues = _service.GetAll();

            return Ok(allIssues);
        }
        [HttpGet("{issueId}")]
        [Authorize(Roles = "Menager,Admin")]
        public ActionResult<UsersIssues> GetById([FromRoute]int issueId)
        {
            var issue = _service.GetById(issueId);
            return Ok(issue);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create([FromBody]CreateUserIssueDto dto)
        {
            _service.Create(dto);
            return Ok("Issue created");
        }
        [HttpDelete]
        [Authorize(Roles = "Menager,Admin")]
        public ActionResult DeleteAll()
        {
            _service.DeleteAll();
            return NoContent();
        }
        [HttpDelete("{issueId}")]
        [Authorize(Roles = "Menager,Admin")]
        public ActionResult DeleteById([FromRoute]int issueId)
        {
            _service.DeleteById(issueId);
            return NoContent();
        }



    }
}
