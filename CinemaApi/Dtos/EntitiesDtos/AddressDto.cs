using System.ComponentModel.DataAnnotations;

namespace CinemaApi.Dtos.EntitiesDtos
{
    public class AddressDto
    {

        public int Id { get; set; }
        [Required]
        public string CinemaName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }
}
