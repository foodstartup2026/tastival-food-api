namespace TastivalFood.Api.Models.Auth
{
    public sealed class RegisterRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string RestaurantName { get; set; } = null!;
        public List<Guid> RestaurantTypeIds { get; set; } = [];
    }
}
