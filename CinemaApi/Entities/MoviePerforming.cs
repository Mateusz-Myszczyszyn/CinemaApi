using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class MoviePerforming
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public int CinemaHallId { get; set; }
        

    }
}
