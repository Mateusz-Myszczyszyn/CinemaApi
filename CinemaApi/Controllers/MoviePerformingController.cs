using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
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
    [Route("api/movieperforming")]
    [ApiController]
    public class MoviePerformingController :ControllerBase
    {
        private readonly IMoviePerformingService _service;

        public MoviePerformingController(IMoviePerformingService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<MoviePerformingDto>> GetAll()
        {
            var results = _service.GetAll();

            return Ok(results);
        }

        [HttpGet("{moviePerfId}")]
        public ActionResult<MoviePerformingDto> GetById([FromRoute]int moviePerfId)
        {
            var moviePerf = _service.GetById(moviePerfId);

            return moviePerf;
        }

        [HttpPost]
        public ActionResult<int> Create(CreateMoviePerformanceDto dto)
        {
            var newMoviePerfId = _service.Create(dto);

            return Created($"api/movieperforming/{newMoviePerfId}", null);
        }
    }
}
