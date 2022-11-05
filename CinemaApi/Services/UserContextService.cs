using CinemaApi.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly HttpContextAccessor _httpContextAccessor;

        public UserContextService(HttpContextAccessor httpContextAccessor)
        {                                                        
            _httpContextAccessor = httpContextAccessor;                          
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public int? GetUserId =>
            User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);


    }
}
