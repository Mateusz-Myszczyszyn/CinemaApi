using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Authorization
{
    public class AgeForMovieRequirement : IAuthorizationRequirement
    {
        public int Age { get;}

        public AgeForMovieRequirement(int age)
        {
            Age = age;
        }
    }
}
