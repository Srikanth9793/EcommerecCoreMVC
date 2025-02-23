namespace Ecommerce.Models
{
    public interface IRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsyncs();

        Task<T> GetIdByAsync(int id, QueryOptions<T> options);

        Task AddAsync (T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
