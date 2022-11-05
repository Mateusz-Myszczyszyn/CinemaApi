using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Controllers
{
    [ApiController]
    [Route("api/cinemahall/{cinemaHallId}/hallseat/")]
    public class HallSeatController : ControllerBase
    {
        private readonly IHallSeatService _service;

        public HallSeatController(IHallSeatService service)
        {
            _service = service;
        }
        [HttpGet]
        [Authorize(Roles ="User")]
        public ActionResult<List<HallSeatsDto>> GetAll([FromRoute]int cinemaHallId)
        {
            var hallSeats = _service.GetAll(cinemaHallId);

            return Ok(hallSeats);
        }

       /* [HttpGet("{hallSeatId}")]
        [Authorize(Roles = "User")]
        public ActionResult<HallSeatsDto> GetById([FromRoute] int cinemaHallId, [FromRoute] int hallSeatId)
        {
            var hallSeat = _service.GetById(cinemaHallId, hallSeatId);

            return Ok(hallSeat);
        }*/

        [HttpPost]
        [Authorize(Roles ="Admin,Worker,Menager")]
        public ActionResult<int> Create([FromRoute] int cinemaHallId, [FromBody]CreateHallSeatsDto dto)
        {
            var newSeatId = _service.Create(cinemaHallId, dto);

            return Created($"api/cinemahall/{cinemaHallId}/hallseat/{newSeatId}", null);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin,Worker,Menager")]
        public ActionResult DeleteAll([FromRoute] int cinemaHallId)
        {
            _service.DeleteAll(cinemaHallId);

            return NoContent();
        }

        [HttpDelete("{hallSeatId}")]
        [Authorize(Roles = "Admin,Worker,Menager")]
        public ActionResult DeleteById([FromRoute] int cinemaHallId, [FromRoute] int hallSeatId)
        {
            _service.DeleteById(cinemaHallId,hallSeatId);

            return NoContent();
        }

        [HttpPut("{hallSeatId}")]
        [Authorize(Roles = "Admin,Worker,Menager")]
        public ActionResult Update([FromRoute] int cinemaHallId, [FromRoute] int hallSeatId, [FromBody] CreateHallSeatsDto dto)
        {
            _service.Update(cinemaHallId, hallSeatId, dto);

            return Ok();
        }
    }
}
