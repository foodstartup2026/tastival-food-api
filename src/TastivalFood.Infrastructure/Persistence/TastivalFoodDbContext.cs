using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TastivalFood.Domain.Common;
using TastivalFood.Domain.Entities;

namespace TastivalFood.Infrastructure.Persistence
{
    public sealed class TastivalFoodDbContext : DbContext
    {
        public TastivalFoodDbContext(DbContextOptions<TastivalFoodDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<RestaurantType> RestaurantTypes => Set<RestaurantType>();
        public DbSet<Origin> Origins => Set<Origin>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Allergy> Allergies => Set<Allergy>();
        public DbSet<MenuItem> MenuItems => Set<MenuItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyMenuItemSoftDeleteFilter(modelBuilder);

            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Email).IsRequired();
                builder.Property(x => x.PasswordHash).IsRequired();
                builder.Property(x => x.RestaurantName).IsRequired();
                builder.Property(x => x.IsActive).HasDefaultValue(true);
                builder.Property(x => x.CreatedAt).IsRequired();
                builder.Property(x => x.UpdatedAt).IsRequired();
                builder.HasIndex(x => x.Email).IsUnique();

                builder.HasMany(x => x.RestaurantTypes)
                    .WithMany(x => x.Users)
                    .UsingEntity(j => j.ToTable("UserRestaurantTypes"));
            });

            modelBuilder.Entity<RestaurantType>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired();

                builder.HasData(
                    new { Id = SeedData.RestaurantTypePersian, Name = "Persian" },
                    new { Id = SeedData.RestaurantTypeItalian, Name = "Italian" },
                    new { Id = SeedData.RestaurantTypeCafe, Name = "Cafe" },
                    new { Id = SeedData.RestaurantTypeFastFood, Name = "FastFood" },
                    new { Id = SeedData.RestaurantTypeBakery, Name = "Bakery" },
                    new { Id = SeedData.RestaurantTypeSeafood, Name = "Seafood" });
            });

            modelBuilder.Entity<Origin>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.CountryName).IsRequired();

                builder.HasData(
                    new { Id = SeedData.OriginIran, CountryName = "Iran" },
                    new { Id = SeedData.OriginItaly, CountryName = "Italy" },
                    new { Id = SeedData.OriginFrance, CountryName = "France" },
                    new { Id = SeedData.OriginTurkey, CountryName = "Turkey" },
                    new { Id = SeedData.OriginJapan, CountryName = "Japan" });
            });

            modelBuilder.Entity<Ingredient>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.Description).IsRequired();
            });

            modelBuilder.Entity<Allergy>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.Description).IsRequired();

                builder.HasData(
                    new { Id = SeedData.AllergyGluten, Name = "Gluten", Description = "Gluten allergy" },
                    new { Id = SeedData.AllergyMilk, Name = "Milk", Description = "Milk allergy" },
                    new { Id = SeedData.AllergyPeanut, Name = "Peanut", Description = "Peanut allergy" },
                    new { Id = SeedData.AllergySoy, Name = "Soy", Description = "Soy allergy" },
                    new { Id = SeedData.AllergyEgg, Name = "Egg", Description = "Egg allergy" },
                    new { Id = SeedData.AllergyFish, Name = "Fish", Description = "Fish allergy" },
                    new { Id = SeedData.AllergyShellfish, Name = "Shellfish", Description = "Shellfish allergy" });
            });

            modelBuilder.Entity<MenuItem>(builder =>
            {
                builder.ToTable(tb =>
                {
                    tb.HasCheckConstraint("CK_MenuItems_PopularityScore", "\"PopularityScore\" >= 0 AND \"PopularityScore\" <= 5");
                    tb.HasCheckConstraint("CK_MenuItems_Calories", "\"Calories\" >= 0");
                });

                builder.HasKey(x => x.Id);
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.Description).IsRequired();
                builder.Property(x => x.Calories).IsRequired();
                builder.Property(x => x.PopularityScore).IsRequired();
                builder.Property(x => x.CreatedAt).IsRequired();
                builder.Property(x => x.UpdatedAt).IsRequired();
                builder.Property(x => x.IsDeleted).HasDefaultValue(false);

                builder.HasOne(x => x.Origin)
                    .WithMany(x => x.MenuItems)
                    .HasForeignKey(x => x.OriginId);

                builder.HasOne(x => x.RestaurantOwner)
                    .WithMany(x => x.MenuItems)
                    .HasForeignKey(x => x.RestaurantOwnerId);

                builder.HasMany(x => x.Ingredients)
                    .WithMany(x => x.MenuItems)
                    .UsingEntity(j => j.ToTable("MenuItemIngredients"));

                builder.HasMany(x => x.Allergies)
                    .WithMany(x => x.MenuItems)
                    .UsingEntity(j => j.ToTable("MenuItemAllergies"));
            });

            base.OnModelCreating(modelBuilder);
        }

        private static void ApplyMenuItemSoftDeleteFilter(ModelBuilder modelBuilder)
        {
            var parameter = Expression.Parameter(typeof(MenuItem), "e");
            var property = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
            var condition = Expression.Equal(property, Expression.Constant(false));
            var lambda = Expression.Lambda<Func<MenuItem, bool>>(condition, parameter);

            modelBuilder.Entity<MenuItem>().HasQueryFilter(lambda);
        }
    }
}
