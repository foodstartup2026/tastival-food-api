using TastivalFood.Domain.Common;

namespace TastivalFood.Domain.Entities
{
    public sealed class Origin : BaseEntity
    {
        public string CountryName { get; private set; } = null!;
        public ICollection<MenuItem> MenuItems { get; private set; } = new HashSet<MenuItem>();

        private Origin() { }

        public Origin(string countryName)
        {
            CountryName = countryName;
        }

        public void UpdateCountryName(string countryName)
        {
            CountryName = countryName;
        }
    }
}
