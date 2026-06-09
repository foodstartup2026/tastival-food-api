using TastivalFood.Domain.Enums;

namespace TastivalFood.Application.Dtos
{
    public sealed class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string RestaurantName { get; set; } = null!;
        public List<Guid> RestaurantTypeIds { get; set; } = [];
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
    }
}
