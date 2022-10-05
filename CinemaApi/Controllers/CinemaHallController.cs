using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Entities;
using CinemaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApi.Controllers
{
    [ApiController]
    [Route("api/address/{addressId}/cinemahalls")]
    public class CinemaHallController : ControllerBase
    {
        private readonly ICinemaHallService _service;

        public CinemaHallController(ICinemaHallService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<CinemaHallDto>> GetAll([FromRoute]int addressId)
        {

            var cinemaHalls = _service.GetAll(addressId);

            return Ok(cinemaHalls);

        }

        [HttpGet("{cinemaHallId}")]
        public ActionResult<CinemaHallDto> GetById([FromRoute] int addressId,[FromRoute] int cinemaHallId)
        {
            var cinemaHall = _service.GetById(addressId,cinemaHallId);

            return Ok(cinemaHall);
        }

        [HttpPost]
        public ActionResult<int> Create([FromRoute] int addressId,[FromBody]CreateCinemaHallDto dto)
        {
            var newCinemaHallId = _service.Create(addressId,dto);

           return Created($"api/address/{addressId}/cinemahalls/{newCinemaHallId}", null);
        }

        [HttpDelete]
        public ActionResult DeleteAll([FromRoute] int addressId)
        {
            _service.DeleteAll(addressId);

            return NoContent();
        }

        [HttpDelete("{cinemaHallId}")]
        public ActionResult DeleteById([FromRoute] int addressId,[FromRoute] int cinemaHallId)
        {
            _service.DeleteById(addressId,cinemaHallId);

            return NoContent();
        }

        [HttpPut("{cinemaHallId}")]
        public ActionResult Update([FromRoute] int addressId,[FromRoute] int cinemaHallId, [FromBody] CreateCinemaHallDto dto)
        {
            _service.Update(addressId, cinemaHallId, dto);

            return Ok();
        }
    }
}

