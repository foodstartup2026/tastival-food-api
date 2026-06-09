using TastivalFood.Domain.Entities;

namespace TastivalFood.Application.Common.Interfaces
{
    public interface IRestaurantTypeRepository
    {
        Task<IReadOnlyList<RestaurantType>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}
