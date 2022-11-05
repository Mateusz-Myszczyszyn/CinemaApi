using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Entities;
using CinemaApi.Services;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public ActionResult<List<CinemaHallDto>> GetAll([FromRoute]int addressId)
        {

            var cinemaHalls = _service.GetAll(addressId);

            return Ok(cinemaHalls);

        }

        [HttpGet("{cinemaHallId}")]
        [AllowAnonymous]
        public ActionResult<CinemaHallDto> GetById([FromRoute] int addressId,[FromRoute] int cinemaHallId)
        {
            var cinemaHall = _service.GetById(addressId,cinemaHallId);

            return Ok(cinemaHall);
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Menager")]
        public ActionResult<int> Create([FromRoute] int addressId,[FromBody]CreateCinemaHallDto dto)
        {
            var newCinemaHallId = _service.Create(addressId,dto);

           return Created($"api/address/{addressId}/cinemahalls/{newCinemaHallId}", null);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin,Menager")]
        public ActionResult DeleteAll([FromRoute] int addressId)
        {
            _service.DeleteAll(addressId);

            return NoContent();
        }

        [HttpDelete("{cinemaHallId}")]
        [Authorize(Roles = "Admin,Menager")]
        public ActionResult DeleteById([FromRoute] int addressId,[FromRoute] int cinemaHallId)
        {
            _service.DeleteById(addressId,cinemaHallId);

            return NoContent();
        }

        [HttpPut("{cinemaHallId}")]
        [Authorize(Roles = "Admin,Menager")]
        public ActionResult Update([FromRoute] int addressId,[FromRoute] int cinemaHallId, [FromBody] CreateCinemaHallDto dto)
        {
            _service.Update(addressId, cinemaHallId, dto);

            return Ok();
        }
    }
}

