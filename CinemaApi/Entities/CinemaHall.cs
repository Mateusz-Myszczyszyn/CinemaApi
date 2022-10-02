using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class CinemaHall
    {
        public int Id { get; set; }
        public string HallName { get; set; }
        public List<Movie> Movies { get; set; }
        public List<SeetReserving> SeetReservings { get; set; }
        public List<Address> Addresses { get; set; }


    }
}
