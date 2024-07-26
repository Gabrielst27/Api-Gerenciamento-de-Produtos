using ApiProdutos.Context;
using ApiProdutos.Models;
using ApiProdutos.Pagination;
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

        public IEnumerable<T> GetPag(GenericParameters genericParameters)
        {
            return GetAll()
                .Skip((genericParameters.PageNumber - 1) * genericParameters.PageSize)
                .Take(genericParameters.PageSize).ToList();
        }

        public IEnumerable<T?> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T? Create(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }
            
        public T? Update(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public T? Delete(Expression<Func<T, bool>> predicate)
        {
            var entity = _context.Set<T>().AsNoTracking().FirstOrDefault(predicate);

            _context.Remove(entity);
            
            return entity;
        }
    }
}
