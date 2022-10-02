using CinemaApi.Dtos;
using CinemaApi.Entities;
using CinemaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApi.Controllers
{
    [ApiController]
    [Route("api/cinemahalls")]
    public class CinemaHallController : ControllerBase
    {
        private readonly ICinemaHallService _service;

        public CinemaHallController(ICinemaHallService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<CinemaHallDto>> GetAll()
        {

            var cinemaHalls = _service.GetAll();

            return Ok(cinemaHalls);

        }

        [HttpGet("{cinemaHallId}")]
        public ActionResult<CinemaHallDto> GetById([FromRoute] int cinemaHallId)
        {
            var cinemaHall = _service.GetById(cinemaHallId);

            return Ok(cinemaHall);
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody]CreateCinemaHallDto dto)
        {
            var newCinemaHallId = _service.Create(dto);

           return Created($"api/cinemahalls/{newCinemaHallId}", null);
        }

        [HttpDelete]
        public ActionResult DeleteAll()
        {
            _service.DeleteAll();

            return NoContent();
        }

        [HttpDelete("{cinemaHallId}")]
        public ActionResult DeleteById([FromRoute] int cinemaHallId)
        {
            _service.DeleteById(cinemaHallId);

            return NoContent();
        }
    }
}

