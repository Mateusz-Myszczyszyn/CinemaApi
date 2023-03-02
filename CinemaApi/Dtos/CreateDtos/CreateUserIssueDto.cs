using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.CreateDtos
{
    public class CreateUserIssueDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string IssueName { get; set; }
        public DateTime ReceiveDate { get; set; } = DateTime.Now;
    }
}
