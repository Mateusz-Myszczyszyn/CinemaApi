using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class SeatReservation
    {
        public int Id { get; set; }
        public string Row { get; set; }
        public int Seat { get; set; }
        public bool IsReserved { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
