using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Dtos.Pagination;
using CinemaApi.Entities;
using CinemaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Controllers
{
    [Route("api/movieperforming")]
    [ApiController]
    public class MoviePerformingController : ControllerBase
    {
        private readonly IMoviePerformingService _service;

        public MoviePerformingController(IMoviePerformingService service)
        {
            _service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<MoviePerformingDto>> GetAll([FromQuery]MoviePerformingQuery query)
        {
            var results = _service.GetAll(query);

            return Ok(results);
        }

        [HttpGet("{moviePerfId}")]
        [AllowAnonymous]
        public ActionResult<MoviePerformingDto> GetById([FromRoute] int moviePerfId)
        {
            var moviePerf = _service.GetById(moviePerfId);

            return moviePerf;
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Menager,Worker")]
        public ActionResult<int> Create(CreateMoviePerformanceDto dto)
        {
            var newMoviePerfId = _service.Create(dto);

            return Created($"api/movieperforming/{newMoviePerfId}", null);
        }

        [HttpDelete("{moviePerfId}")]
        [Authorize(Roles = "Admin,Menager,Worker")]
        public ActionResult DeleteById([FromRoute]int moviePerfId)
        {
            _service.DeleteById(moviePerfId);

            return NoContent();
        }

        [HttpPut("{moviePerfId}")]
        [Authorize(Roles = "Admin,Menager,Worker")]
        public ActionResult Update([FromRoute] int moviePerfId, [FromBody] CreateMoviePerformanceDto dto)
        {
            _service.Update(moviePerfId, dto);

            return Ok();
        }
    }
}
