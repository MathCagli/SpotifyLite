using System.Data;
using System.Linq.Expressions;

namespace SpotifyLite.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        //Task<IDbContextTransaction> CreateTransaction();
        //Task<IDbContextTransaction> CreateTransaction(IsolationLevel isolation);
        Task Delete(T entity);
        Task<IEnumerable<T>> FindAllByCriteria(Expression<Func<T, bool>> expression);
        Task<T> FindOneByCriteria(Expression<Func<T, bool>> expression);
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Save(T entity);
        Task Update(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        bool Exists(Expression<Func<T, bool>> expression);
    }
}