﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
