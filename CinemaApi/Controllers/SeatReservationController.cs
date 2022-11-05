using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Entities;
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
    [Route("api/reservation")]
    [ApiController]
    public class SeatReservationController : ControllerBase
    {
        private readonly ISeatReservationService _service;

        public SeatReservationController(ISeatReservationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Menager,Worker,Admin")]
        public ActionResult<List<SeatReservation>> GetAll()
        {
            var reservations = _service.GetAll();

            return Ok(reservations);
        }

        [HttpGet("{reservationId}")]
        [Authorize(Roles = "Menager,Worker,Admin")]
        public ActionResult<SeatReservation> GetById([FromRoute] int reservationId)
        {
            var reservation = _service.GetById(reservationId);

            return Ok(reservation);
        }

        [HttpPost]
        [Authorize(Roles ="User")]
        public ActionResult<int> Create([FromBody] CreateSeatReservationDto dto)
        {
            var reservationId = _service.Create(dto);

            return Created($"/api/reservation/{reservationId}", null);
        }

        [HttpDelete("{reservationId}")]
        [Authorize(Roles ="Worker,Menager,Admin")]
        public ActionResult DeleteById([FromRoute]int reservationId)
        {
            _service.DeleteById(reservationId);

            return NoContent();
        }

        [HttpPut("{reservationId}")]
        [Authorize(Roles ="Worker,Menager,Admin")]
        public ActionResult Update([FromRoute]int reservationId, [FromBody]UpdateSeatReservationDto dto)
        {
            _service.Update(reservationId, dto);

            return Ok();
        }
    }
}
