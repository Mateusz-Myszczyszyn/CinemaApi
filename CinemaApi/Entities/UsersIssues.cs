using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class UsersIssues
    { 
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string IssueName { get; set; }
        public DateTime ReceiveDate { get; set; }
    }
}
