using CinemaApi.Dtos.CreateDtos;
using CinemaApi.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.Validators
{
    public class CreateMovieDtoValidator : AbstractValidator<CreateMovieDto>
    {
        private int[] allowedPEGI = new[] { 3, 7, 12, 16, 18 };
        public CreateMovieDtoValidator(CinemaDbContext dbContext)
        {
            RuleFor(c => c.PEGI).Custom((value, context) =>
            {
                if (!allowedPEGI.Contains(value))
                {
                    context.AddFailure("PEGI", $"PEGI range must be in range : [{string.Join(",", allowedPEGI)}]");
                }
            });
            RuleFor(c => c.Title).NotEmpty().MaximumLength(20);
            RuleFor(c => c.Description).MaximumLength(100);
            RuleFor(c => c.Director).NotEmpty().MaximumLength(25);
            RuleFor(c => c.Cast).MaximumLength(50);
          
        }
    }
}
