using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class AddressHasHalls
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int CinemaHallId { get; set; }
        public CinemaHall CinemaHall { get; set; }

    }
}
