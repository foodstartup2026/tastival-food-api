using MediatR;
using TastivalFood.Application.Dtos;

namespace TastivalFood.Application.Features.Auth.Commands.RegisterUser
{
    public sealed class RegisterUserCommand : IRequest<UserDto>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string RestaurantName { get; set; } = null!;
        public List<Guid> RestaurantTypeIds { get; set; } = [];
    }
}
