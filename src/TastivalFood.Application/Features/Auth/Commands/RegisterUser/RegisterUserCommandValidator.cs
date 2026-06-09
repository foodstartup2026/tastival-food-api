using FluentValidation;

namespace TastivalFood.Application.Features.Auth.Commands.RegisterUser
{
    public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.RestaurantName)
                .NotEmpty();

            RuleFor(x => x.RestaurantTypeIds)
                .NotEmpty();

            RuleForEach(x => x.RestaurantTypeIds)
                .NotEmpty();
        }
    }
}
