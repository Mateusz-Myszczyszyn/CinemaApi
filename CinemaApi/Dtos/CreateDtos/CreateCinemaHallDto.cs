using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.CreateDtos
{
    public class CreateCinemaHallDto
    {
        [Required]
        public string HallName { get; set; }
    }
}
