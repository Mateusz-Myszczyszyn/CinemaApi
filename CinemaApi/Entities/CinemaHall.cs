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
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
        public List<SeetReserving> SeetReservings { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }


    }
}
