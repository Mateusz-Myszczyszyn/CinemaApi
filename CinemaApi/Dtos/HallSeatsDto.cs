using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos
{
    public class HallSeatsDto
    {
        public int Id { get; set; }
        public string Row { get; set; }
        public string Seat { get; set; }
    }
}
