using CinemaApi.Dtos.Pagination;
using CinemaApi.Entities;
using FluentValidation;

namespace CinemaApi.Dtos.Validators
{
    public class AddressQueryValidator : AbstractValidator<AddressQuery>
    {
        private int[] allowedPageSizes = { 5, 10, 15, 20 };
        private string[] allowedSortByColumnNames = { nameof(Address.City), nameof(Address.Street)};
        public AddressQueryValidator()
        {
            RuleFor(c => c.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(c => c.PageItems).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageItems", $"PageItems should be in [{string.Join(",", allowedPageSizes)}]");
                }
            });

            RuleFor(c=>c.SortBy).Must(value=>string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",",allowedSortByColumnNames)}]");
        }
    }
}
