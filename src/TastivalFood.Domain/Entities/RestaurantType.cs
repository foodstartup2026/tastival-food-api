using TastivalFood.Domain.Common;

namespace TastivalFood.Domain.Entities
{
    public sealed class RestaurantType : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public ICollection<User> Users { get; private set; } = new HashSet<User>();

        private RestaurantType() { }

        public RestaurantType(string name)
        {
            Name = name;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
