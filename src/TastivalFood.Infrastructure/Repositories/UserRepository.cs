using Microsoft.EntityFrameworkCore;
using TastivalFood.Application.Common.Interfaces;
using TastivalFood.Domain.Entities;
using TastivalFood.Infrastructure.Persistence;

namespace TastivalFood.Infrastructure.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly TastivalFoodDbContext _dbContext;

        public UserRepository(TastivalFoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken = default)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Users.FindAsync(new object[] { id }, cancellationToken);
        }
    }
}
