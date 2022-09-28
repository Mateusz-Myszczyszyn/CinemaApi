using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos
{
    public class CreateCinemaHallDto
    {
        [Required]
        public string Name { get; set; }
    }
}
