using MediatR;
using TastivalFood.Application.Dtos;

namespace TastivalFood.Application.Features.Auth.Commands.LoginUser
{
    public sealed class LoginUserCommand : IRequest<AuthResult>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
