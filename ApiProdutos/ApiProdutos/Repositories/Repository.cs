using ApiProdutos.Context;
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

        public T? GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }
    }
}
