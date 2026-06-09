using FluentAssertions;
using TastivalFood.Application.Features.Auth.Commands.RegisterUser;
using Xunit;

namespace TastivalFood.UnitTests
{
    public sealed class RegisterUserCommandValidatorTests
    {
        [Fact]
        public void Validate_WhenEmailIsInvalid_ShouldReturnValidationError()
        {
            var validator = new RegisterUserCommandValidator();
            var command = new RegisterUserCommand
            {
                Email = "invalid-email",
                Password = "password123"
            };

            var result = validator.Validate(command);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(error => error.PropertyName == "Email");
        }
    }
}
