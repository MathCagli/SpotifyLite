using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SpotifyLite.Repository.Context;
using SpotifyLite.Domain.Repositories;
using System.Data;
using System.Linq.Expressions;

namespace SpotifyLite.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Query { get; set; }
        protected DbContext Context { get; set; }

        public Repository(SpotifyLiteContext context)
        {
            Context = context;
            Query = Context.Set<T>();
        }

        public async Task<IDbContextTransaction> CreateTransaction()
        {
            return await Context.Database.BeginTransactionAsync();
        }

        public async Task<IDbContextTransaction> CreateTransaction(IsolationLevel isolation)
        {
            return await Context.Database.BeginTransactionAsync(isolation);
        }

        public async Task Delete(T entity)
        {
            Query.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAllByCriteria(Expression<Func<T, bool>> expression)
        {
            return await Query.Where(expression).ToListAsync();
        }

        public async Task<T> FindOneByCriteria(Expression<Func<T, bool>> expression)
        {
            return await Query.FirstOrDefaultAsync(expression);
        }

        public async Task<T> Get(Guid id)
        {
            return await Query.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Query.ToListAsync();
        }

        public async Task Save(T entity)
        {
            Query.Add(entity);
            Context.SaveChanges();
        }

        public async Task Update(T entity)
        {
            Query.Update(entity);
            await Context.SaveChangesAsync();

        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return Find(expression).Any();
        }
    }
}