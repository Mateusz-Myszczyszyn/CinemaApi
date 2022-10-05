using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.EntitiesDtos
{
    public class MoviePerformingDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CinemaHallId { get; set; }
    }
}
