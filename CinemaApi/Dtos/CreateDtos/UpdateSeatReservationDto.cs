using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.CreateDtos
{
    public class UpdateSeatReservationDto
    {
        public bool IsReserved { get; set; }
        public bool Active { get; set; }
        public int HallSeatId { get; set; }
        public int ScreenPlayId { get; set; }
    }
}
