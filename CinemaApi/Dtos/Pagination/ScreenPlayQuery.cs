using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.Pagination
{
    public class ScreenPlayQuery
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageItems { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
