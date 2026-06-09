using TastivalFood.Domain.Common;
using TastivalFood.Domain.Enums;

namespace TastivalFood.Domain.Entities
{
    public sealed class MenuItem : AuditableEntity, ISoftDelete
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public MenuCategory Category { get; private set; }
        public int Calories { get; private set; }
        public decimal PopularityScore { get; private set; }
        public bool IsAlcoholic { get; private set; }
        public bool IsHalal { get; private set; }
        public Guid OriginId { get; private set; }
        public Origin Origin { get; private set; } = null!;
        public Guid RestaurantOwnerId { get; private set; }
        public User RestaurantOwner { get; private set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Ingredient> Ingredients { get; private set; } = new HashSet<Ingredient>();
        public ICollection<Allergy> Allergies { get; private set; } = new HashSet<Allergy>();

        private MenuItem() { }

        public MenuItem(
            string name,
            string description,
            MenuCategory category,
            int calories,
            decimal popularityScore,
            bool isAlcoholic,
            bool isHalal,
            Guid originId,
            Guid restaurantOwnerId)
        {
            Name = name;
            Description = description;
            Category = category;
            SetCalories(calories);
            SetPopularityScore(popularityScore);
            IsAlcoholic = isAlcoholic;
            IsHalal = isHalal;
            OriginId = originId;
            RestaurantOwnerId = restaurantOwnerId;
        }

        public void MarkDeleted()
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            UpdateTimestamp();
        }

        public void SetCalories(int calories)
        {
            if (calories < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(calories), "Calories must be greater than or equal to zero.");
            }

            Calories = calories;
            UpdateTimestamp();
        }

        public void SetPopularityScore(decimal popularityScore)
        {
            if (popularityScore < 0 || popularityScore > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(popularityScore), "PopularityScore must be between 0 and 5.");
            }

            PopularityScore = popularityScore;
            UpdateTimestamp();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            UpdateTimestamp();
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
            UpdateTimestamp();
        }

        public void AddAllergy(Allergy allergy)
        {
            Allergies.Add(allergy);
            UpdateTimestamp();
        }

        public void RemoveAllergy(Allergy allergy)
        {
            Allergies.Remove(allergy);
            UpdateTimestamp();
        }
    }
}
