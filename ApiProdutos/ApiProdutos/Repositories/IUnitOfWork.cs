using ApiProdutos.Models;

namespace ApiProdutos.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Armazem> ArmazemRepository { get; }
        IRepository<Categoria> CategoriaRepository { get; }
        IRepository<Contrato> ContratoRepository { get; }
        IRepository<Fornecedor> FornecedorRepository { get; }
        IRepository<ItemArmazem> ItemArmazemRepository { get; }
        IRepository<ItemContrato> ItemContratoRepository { get; }
        IRepository<Produto> ProdutoRepository { get; }
        IRepository<Subcategoria> SubcategoriaRepository { get; }
        void Commit();
    }
}
