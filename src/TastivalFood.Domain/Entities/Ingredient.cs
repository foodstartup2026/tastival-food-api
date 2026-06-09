using TastivalFood.Domain.Common;

namespace TastivalFood.Domain.Entities
{
    public sealed class Ingredient : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public ICollection<MenuItem> MenuItems { get; private set; } = new HashSet<MenuItem>();

        private Ingredient() { }

        public Ingredient(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void UpdateDetails(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
