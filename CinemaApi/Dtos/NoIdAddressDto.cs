﻿using System.ComponentModel.DataAnnotations;

namespace CinemaApi.Dtos
{
    public class NoIdAddressDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }
}
