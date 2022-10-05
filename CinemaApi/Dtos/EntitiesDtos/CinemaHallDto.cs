using CinemaApi.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.EntitiesDtos
{
    public class CinemaHallDto
    {
        public int Id { get; set; }
        [Required]
        public string HallName { get; set; }


    }
}
