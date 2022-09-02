using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class SeetReserving
    {
        public int Id { get; set; }
        public string Rows { get; set; }
        public int Seats { get; set; }
        public bool IsReserved { get; set; }

        public CinemaHall CinemaHall { get; set; }
        public int CinemaHallId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
