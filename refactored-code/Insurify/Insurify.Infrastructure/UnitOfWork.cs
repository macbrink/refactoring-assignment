using Insurify.Domain.Abstractions;

namespace Insurify.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}