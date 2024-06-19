using ApiProdutos.Models;
using System.Linq.Expressions;

namespace ApiProdutos.Repositories
{
    public interface IRepository<T>
    {
        T? Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T?> GetAll();
        T? Create(T entity);
        T? Update(T entity);
        T? Delete(Expression<Func<T, bool>> predicate);
    }
}
