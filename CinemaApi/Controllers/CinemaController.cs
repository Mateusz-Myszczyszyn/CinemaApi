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
    [Route("api/cinema")]
    [ApiController]
    public class CinemaController
    {
        private readonly ICinemaService _service;

        public CinemaController(ICinemaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IResult GetAll()
        {
            var cinemas =_service.GetAll();

            return Results.Ok(cinemas);
            
        }

        [HttpGet("/{id}")]
        public IResult GetById([FromRoute]int id)
        {
            var cinema = _service.GetById(id);

            return Results.Ok(cinema);
        }
    }
}
