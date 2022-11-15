using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Dtos.EntitiesDtos;
using CinemaApi.Dtos.Pagination;
using CinemaApi.Entities;
using CinemaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApi.Controllers
{
    [ApiController]
    [Route("api/cinema/{cinemaId}/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<AddressDto>> GetAll([FromRoute] int cinemaId, [FromQuery]AddressQuery query)
        {
            var Addresses = _service.GetAll(cinemaId,query);

            return Ok(Addresses);
        }

        [HttpGet("{addressId}")]
        [AllowAnonymous]
        public ActionResult<AddressDto> GetById([FromRoute] int cinemaId, [FromRoute] int addressId)
        {
            var specificAddress = _service.GetById(cinemaId, addressId);

            return Ok(specificAddress);
        }

        [HttpPost]
        [Authorize(Roles ="Menager,Admin")]
        public ActionResult Create([FromRoute] int cinemaId, [FromBody] CreateAddressDto dto)
        {
            var newAddressId = _service.Create(cinemaId, dto);

            return Created($"api/cinema/{cinemaId}/address/{newAddressId}", null);
        }

        [HttpDelete("{addressId}")]
        [Authorize(Roles = "Menager,Admin")]
        public ActionResult DeleteById([FromRoute] int cinemaId, [FromRoute] int addressId)
        {
            _service.DeleteById(cinemaId, addressId);

            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Menager,Admin")]
        public ActionResult DeleteAll([FromRoute] int cinemaId)
        {
            _service.DeleteAll(cinemaId);

            return NoContent();
        }

        [HttpPut("{addressId}")]
        [Authorize(Roles = "Menager,Admin")]
        public ActionResult Update([FromRoute] int cinemaId, [FromRoute] int addressId, [FromBody] CreateAddressDto dto)
        {
            _service.Update(cinemaId, addressId, dto);

            return Ok();
        }


    }
}
