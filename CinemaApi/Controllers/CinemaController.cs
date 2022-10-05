using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Entities;
using CinemaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApi.Controllers
{
    [Route("api/cinema")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaService _service;

        public CinemaController(ICinemaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<Cinema>GetAll()
        {
            var cinemas = _service.GetAll();

            return Ok(cinemas);
            
        }

        [HttpGet("{id}")]
        public ActionResult<Cinema> GetById([FromRoute]int id)
        {
            var cinema =_service.GetById(id);

            return Ok(cinema);
        }

        [HttpPost]
        public ActionResult Create([FromBody]CreateCinemaDto dto)
        {
            var createdId = _service.Create(dto);

            return Created($"/api/cinema/{createdId}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            _service.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]CreateCinemaDto dto,[FromRoute] int id)
        {
            _service.Update(dto, id);

            return Ok();
        }
    }
}
