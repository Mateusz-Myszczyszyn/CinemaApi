﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public int PEGI { get;set; }
        public DateTime? Premiere { get; set; }
        public List<CinemaHall> CinemaHalls { get; set; }
    }
}
