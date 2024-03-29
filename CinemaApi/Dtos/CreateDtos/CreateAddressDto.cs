﻿using System.ComponentModel.DataAnnotations;

namespace CinemaApi.Dtos.CreateDtos
{
    public class CreateAddressDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }
}
