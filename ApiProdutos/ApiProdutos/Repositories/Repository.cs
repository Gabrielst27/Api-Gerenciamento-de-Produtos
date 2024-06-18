using ApiProdutos.Context;
using ApiProdutos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiProdutos.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PostgreSqlDbContext _context;

        public Repository(PostgreSqlDbContext context)
        {
            _context = context;
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }

        public IEnumerable<T?> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }
            
        public T? Update(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return entity;
        }
    }
}
