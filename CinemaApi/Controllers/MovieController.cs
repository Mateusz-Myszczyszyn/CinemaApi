using CinemaApi.Dtos;
using CinemaApi.Entities;
using CinemaApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<MovieDto>> GetAll()
        {
            var movies = _service.GetAll();

            return Ok(movies);
        }

        [HttpGet("{movieId}")]
        public ActionResult<MovieDto> GetById([FromRoute]int movieId)
        {
            var movie = _service.GetById(movieId);

            return Ok(movie); 
        }

        [HttpDelete]
        public ActionResult DeleteAll()
        {
            _service.DeleteAll();

            return NoContent();
        }

        [HttpDelete("{movieId}")]
        public ActionResult DeleteById([FromRoute]int movieId)
        {
            _service.DeleteById(movieId);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody]CreateMovieDto dto)
        {
            var createdMovieId = _service.Create(dto);

            return Created($"api/movie/{createdMovieId}",null);
        }

        [HttpPut("{movieId}")]
        public ActionResult Update([FromBody] CreateMovieDto dto, [FromRoute] int movieId)
        {
            _service.Update(movieId, dto);

            return Ok();
        }

    }
}
