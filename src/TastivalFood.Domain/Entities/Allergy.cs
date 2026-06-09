using TastivalFood.Domain.Common;

namespace TastivalFood.Domain.Entities
{
    public sealed class Allergy : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public ICollection<MenuItem> MenuItems { get; private set; } = new HashSet<MenuItem>();

        private Allergy() { }

        public Allergy(string name, string description)
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
