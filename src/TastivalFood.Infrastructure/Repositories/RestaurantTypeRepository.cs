using Microsoft.EntityFrameworkCore;
using TastivalFood.Application.Common.Interfaces;
using TastivalFood.Domain.Entities;
using TastivalFood.Infrastructure.Persistence;

namespace TastivalFood.Infrastructure.Repositories
{
    public sealed class RestaurantTypeRepository : IRestaurantTypeRepository
    {
        private readonly TastivalFoodDbContext _dbContext;

        public RestaurantTypeRepository(TastivalFoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<RestaurantType>> GetByIdsAsync(
            IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default)
        {
            var idList = ids.Distinct().ToList();

            return await _dbContext.RestaurantTypes
                .Where(x => idList.Contains(x.Id))
                .ToListAsync(cancellationToken);
        }
    }
}
