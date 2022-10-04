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
        public bool IsReserved { get; set; }
        public bool Payed { get; set; }
        public bool Active { get; set; }
        public int HallSeatId { get; set; }
        public HallSeats HallSeats { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int ScreenPlayId { get; set; }
        public ScreenPlay ScreenPlay { get; set; }
    }
}
