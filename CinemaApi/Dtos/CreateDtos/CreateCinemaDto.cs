using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.CreateDtos
{
    public class CreateCinemaDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Owner { get; set; }
        public int WorkersQuantity { get; set; }

    }
}
