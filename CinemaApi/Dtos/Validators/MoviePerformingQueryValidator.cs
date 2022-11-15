using CinemaApi.Dtos.Pagination;
using CinemaApi.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Dtos.Validators
{

    public class MoviePerformingQueryValidator : AbstractValidator<MoviePerformingQuery>
    {
        private int[] allowedPageSizes = { 5, 10 };
        private string[] allowedSortByColumnNames = { nameof(MoviePerforming.Movie.Title), nameof(MoviePerforming.CinemaHall.HallName) };

        public MoviePerformingQueryValidator()
        {
            RuleFor(c => c.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(c => c.PageItems).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageItems", $"PageItems should be in [{string.Join(",", allowedPageSizes)}]");
                }
            });

            RuleFor(c => c.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
