using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace BookDAL.Context
{
    public interface IBookContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
