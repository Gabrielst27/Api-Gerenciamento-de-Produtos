using System.Linq.Expressions;

namespace ApiProdutos.Repositories
{
    public interface IRepository<T>
    {
        T? GetById(Expression<Func<T, bool>> predicate);
    }
}
