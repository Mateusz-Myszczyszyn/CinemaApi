using CinemaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.EntitiesDtos
{
    public class ScreenPlayDto
    {
        public int Id { get; set; }
        public DateTime ShowTime { get; set; }
        public MoviePerformingDto MoviePerformingDto { get; set; }
    }
}
