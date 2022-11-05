using CinemaApi.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Authorization
{
    public class AgeForMovieRequirementHandler : AuthorizationHandler<AgeForMovieRequirement>
    {
        private readonly ILogger<AgeForMovieRequirement> _logger;

        public AgeForMovieRequirementHandler(ILogger<AgeForMovieRequirement> logger)
        {
            _logger = logger;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeForMovieRequirement requirement)
        {
           
            var UserDate = DateTime.Parse(context.User.FindFirst(c => c.Type == "DateOfBirth").Value);
            var UserEmail = context.User.FindFirst(c => c.Type == ClaimTypes.Email).Value;

            if(UserDate.AddYears(requirement.Age) <= DateTime.Today)
            {
                _logger.LogInformation($"User with email{UserEmail} and DateOfBirth {UserDate} done action");
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogInformation("Authorization failed");
            }
            return Task.CompletedTask;

        }
    }
}
