using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class MoviePerforming
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public int CinemaHallId { get; set; }
        public List<DateTime> PerformingDates { get; set; } = new List<DateTime>();

    }
}
