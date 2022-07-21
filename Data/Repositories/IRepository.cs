using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationTest.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<List<T>> ReadAllAsync();
        Task<List<T>> ReadAllAsync(Expression<Func<T, bool>> filter);
        Task<(List<T>, int)> ReadAllFilterAsync(int skip, int take);
        Task<T> ReadAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
    }
}
