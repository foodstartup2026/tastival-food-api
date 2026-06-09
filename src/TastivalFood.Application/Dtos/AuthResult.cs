namespace TastivalFood.Application.Dtos
{
    public sealed class AuthResult
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public UserDto User { get; set; } = null!;
    }
}
