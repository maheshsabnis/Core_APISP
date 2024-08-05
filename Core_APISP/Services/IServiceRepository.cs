using System.Collections.Generic;
using System.Threading.Tasks;

public interface IServiceRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
