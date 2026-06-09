namespace TastivalFood.Infrastructure.Persistence
{
    internal static class SeedData
    {
        public static readonly Guid RestaurantTypePersian = new("a1000001-0000-4000-8000-000000000001");
        public static readonly Guid RestaurantTypeItalian = new("a1000001-0000-4000-8000-000000000002");
        public static readonly Guid RestaurantTypeCafe = new("a1000001-0000-4000-8000-000000000003");
        public static readonly Guid RestaurantTypeFastFood = new("a1000001-0000-4000-8000-000000000004");
        public static readonly Guid RestaurantTypeBakery = new("a1000001-0000-4000-8000-000000000005");
        public static readonly Guid RestaurantTypeSeafood = new("a1000001-0000-4000-8000-000000000006");

        public static readonly Guid OriginIran = new("b2000001-0000-4000-8000-000000000001");
        public static readonly Guid OriginItaly = new("b2000001-0000-4000-8000-000000000002");
        public static readonly Guid OriginFrance = new("b2000001-0000-4000-8000-000000000003");
        public static readonly Guid OriginTurkey = new("b2000001-0000-4000-8000-000000000004");
        public static readonly Guid OriginJapan = new("b2000001-0000-4000-8000-000000000005");

        public static readonly Guid AllergyGluten = new("c3000001-0000-4000-8000-000000000001");
        public static readonly Guid AllergyMilk = new("c3000001-0000-4000-8000-000000000002");
        public static readonly Guid AllergyPeanut = new("c3000001-0000-4000-8000-000000000003");
        public static readonly Guid AllergySoy = new("c3000001-0000-4000-8000-000000000004");
        public static readonly Guid AllergyEgg = new("c3000001-0000-4000-8000-000000000005");
        public static readonly Guid AllergyFish = new("c3000001-0000-4000-8000-000000000006");
        public static readonly Guid AllergyShellfish = new("c3000001-0000-4000-8000-000000000007");
    }
}
