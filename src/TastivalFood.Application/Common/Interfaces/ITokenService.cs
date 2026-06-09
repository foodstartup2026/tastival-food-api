using TastivalFood.Application.Dtos;

namespace TastivalFood.Application.Common.Interfaces
{
    public interface ITokenService
    {
        string CreateAccessToken(UserDto user);
        string CreateRefreshToken();
    }
}
