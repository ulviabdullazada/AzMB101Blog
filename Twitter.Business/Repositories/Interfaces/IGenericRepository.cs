using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Twitter.Core.Entities.Common;

namespace Twitter.Business.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        IQueryable<T> GetAll(bool noTracking = true, params string[] include);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool noTracking = true, params string[] include);
        Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] include);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T data);
        void Remove(T data);
        Task SaveAsync();
    }
}
