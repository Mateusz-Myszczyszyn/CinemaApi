using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
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
    [Route("api/screenplay")]

    public class ScreenPlayController : ControllerBase
    {
        private readonly IScreenPlayService _service;

        public ScreenPlayController(IScreenPlayService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ScreenPlayDto>> GetAll()
        {
            var screenPlays = _service.GetAll();

            return Ok(screenPlays);
        }

        [HttpGet("{screenPlayId}")]
        public ActionResult<ScreenPlayDto> GetById([FromRoute]int screenPlayId)
        {
            var screenPlay = _service.GetById(screenPlayId);

            return Ok(screenPlay);
        }

        [HttpPost]
        public ActionResult<int> Create([FromBody]CreateScreenPlayDto dto)
        {
            var createdScrPlayId = _service.Create(dto);

            return Created($"api/screenplay/{createdScrPlayId}", null);
        }

        [HttpPut("{screenPlayId}")]
        public ActionResult Update([FromRoute] int screenPlayId, [FromBody] CreateScreenPlayDto dto)
        {
            _service.Update(screenPlayId, dto);

            return Ok();
        }

        [HttpDelete("{screenPlayId}")]
        public ActionResult DeleteById([FromRoute]int screenPlayId)
        {
            _service.DeleteById(screenPlayId);

            return NoContent();
        }

       /* [HttpDelete]
        public ActionResult DeleteAll()
        {
            _service.DeleteAll();

            return NoContent();
        }*/
    }
}
