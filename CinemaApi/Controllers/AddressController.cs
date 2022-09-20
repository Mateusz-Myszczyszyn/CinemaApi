using CinemaApi.Dtos;
using CinemaApi.Entities;
using CinemaApi.Services;
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
        public ActionResult<List<AddressDto>> GetAll([FromRoute]int cinemaId)
        {
            var Addresses = _service.GetAll(cinemaId);

            return Ok(Addresses);
        }


    }
}
