using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class HallSeats
    {
        public int Id { get; set; }
        public string Row { get; set; }
        public string Seat { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public int CinemaHallId { get; set; }
    }
}
