using Domain.SharedKernel;
using System.Linq.Expressions;

namespace Domain.SharedKernel
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includeExpressions);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeExpressions);

        Task<T> GetAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}