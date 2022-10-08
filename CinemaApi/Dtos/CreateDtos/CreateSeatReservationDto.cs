using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.CreateDtos
{
    public class CreateSeatReservationDto
    {
        public bool IsReserved { get; set; }
        public bool Active { get; set; }
        public int HallSeatId { get; set; }
        public int UserId { get; set; }
        public int ScreenPlayId { get; set; }
    }
}
