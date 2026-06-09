using TastivalFood.Domain.Common;
using TastivalFood.Domain.Enums;

namespace TastivalFood.Domain.Entities
{
    public sealed class User : AuditableEntity
    {
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public string RestaurantName { get; private set; } = null!;
        public UserRole Role { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<RestaurantType> RestaurantTypes { get; private set; } = new HashSet<RestaurantType>();
        public ICollection<MenuItem> MenuItems { get; private set; } = new HashSet<MenuItem>();

        private User() { }

        public User(
            string email,
            string passwordHash,
            string restaurantName,
            IEnumerable<RestaurantType> restaurantTypes,
            UserRole role,
            bool isActive = true)
        {
            Email = email;
            PasswordHash = passwordHash;
            RestaurantName = restaurantName;
            Role = role;
            IsActive = isActive;

            foreach (var restaurantType in restaurantTypes)
            {
                RestaurantTypes.Add(restaurantType);
            }
        }

        public void UpdatePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
            UpdateTimestamp();
        }

        public void UpdateRestaurantName(string name)
        {
            RestaurantName = name;
            UpdateTimestamp();
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
            UpdateTimestamp();
        }

        public void ChangeRole(UserRole role)
        {
            Role = role;
            UpdateTimestamp();
        }

        public void AddRestaurantType(RestaurantType restaurantType)
        {
            RestaurantTypes.Add(restaurantType);
            UpdateTimestamp();
        }

        public void RemoveRestaurantType(RestaurantType restaurantType)
        {
            RestaurantTypes.Remove(restaurantType);
            UpdateTimestamp();
        }
    }
}
