﻿using System.ComponentModel.DataAnnotations;

namespace CinemaApi.Dtos
{
    public class CreateMovieDto
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(25)]
        public string Director { get; set; }
        public DateTime? Premiere { get; set; }
    }
}
