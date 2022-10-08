using CinemaApi.Dtos.EntitiesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.CreateDtos
{
    public class CreateScreenPlayDto
    {
        public DateTime ShowTime { get; set; }
        public int MoviePerformingId { get; set; }
    }
}
