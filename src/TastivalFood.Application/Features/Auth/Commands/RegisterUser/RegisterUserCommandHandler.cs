using AutoMapper;
using MediatR;
using TastivalFood.Application.Common.Interfaces;
using TastivalFood.Application.Dtos;
using TastivalFood.Domain.Entities;

namespace TastivalFood.Application.Features.Auth.Commands.RegisterUser
{
    public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantTypeRepository _restaurantTypeRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(
            IUserRepository userRepository,
            IRestaurantTypeRepository restaurantTypeRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _restaurantTypeRepository = restaurantTypeRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
            if (existingUser is not null)
            {
                throw new InvalidOperationException("A user with that email already exists.");
            }

            var restaurantTypes = await _restaurantTypeRepository.GetByIdsAsync(
                request.RestaurantTypeIds,
                cancellationToken);

            if (restaurantTypes.Count != request.RestaurantTypeIds.Distinct().Count())
            {
                throw new InvalidOperationException("One or more restaurant types were not found.");
            }

            var user = new User(
                request.Email,
                BCrypt.Net.BCrypt.HashPassword(request.Password),
                request.RestaurantName,
                restaurantTypes,
                Domain.Enums.UserRole.Restaurant);

            await _userRepository.AddAsync(user, cancellationToken);

            return _mapper.Map<UserDto>(user);
        }
    }
}
