using MediatR;
using Microsoft.AspNetCore.Mvc;
using TastivalFood.Application.Features.Auth.Commands.LoginUser;
using TastivalFood.Application.Features.Auth.Commands.RegisterUser;
using TastivalFood.Api.Models.Auth;

namespace TastivalFood.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var command = new RegisterUserCommand
            {
                Email = request.Email,
                Password = request.Password,
                RestaurantName = request.RestaurantName,
                RestaurantTypeIds = request.RestaurantTypeIds,
            };

            var user = await _sender.Send(command);
            return Created(string.Empty, user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var command = new LoginUserCommand
            {
                Email = request.Email,
                Password = request.Password,
            };

            var authResult = await _sender.Send(command);
            return Ok(authResult);
        }
    }
}
