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
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(CinemaDbContext dbContext)
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Password)
                .NotEmpty()
                .MinimumLength(10);

            RuleFor(c => c.ConfirmPassword)
                .NotEmpty()
                .Equal(c => c.Password);

            RuleFor(c => c.Email)
                .Custom((value, context) =>
                {
                    var checkIfUsed = dbContext.Users.Any(c => c.Email == value);
                    if (checkIfUsed)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

            
        }
    }
}
