using AutoMapper;
using MediatR;
using TastivalFood.Application.Common.Interfaces;
using TastivalFood.Application.Dtos;

namespace TastivalFood.Application.Features.Auth.Commands.LoginUser
{
    public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserRepository userRepository, ITokenService tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<AuthResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var userDto = _mapper.Map<UserDto>(user);
            return new AuthResult
            {
                AccessToken = _tokenService.CreateAccessToken(userDto),
                RefreshToken = _tokenService.CreateRefreshToken(),
                User = userDto,
            };
        }
    }
}
