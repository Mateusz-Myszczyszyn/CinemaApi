﻿using System;
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
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<HallSeats> HallSeats { get; set; }


    }
}
