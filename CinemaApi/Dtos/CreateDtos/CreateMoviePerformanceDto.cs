using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.CreateDtos
{
    public class CreateMoviePerformanceDto
    {
        public int MovieId { get; set; }
        public int CinemaHallId { get; set; }
    }
}
