using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class ScreenPlay
    {
        public int Id { get; set; }
        public DateTime ShowTime { get; set; }
        public MoviePerforming MoviePerforming { get; set; }
        public int MoviePerformingId { get; set; }
    }
}
