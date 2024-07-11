using ApiProdutos.Context;
using ApiProdutos.Models;

namespace ApiProdutos.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Repository<Armazem>? _armazemRep;
        private Repository<Categoria>? _categoriaRep;
        private Repository<Contrato>? _contratoRep;
        private Repository<Fornecedor>? _fornecedorRep;
        private Repository<ItemArmazem>? _itemArmazemRep;
        private Repository<ItemContrato>? _itemContratoRep;
        private Repository<Produto>? _produtoRep;
        private Repository<Subcategoria>? _subcategoriaRep;

        public PostgreSqlDbContext _context;

        public UnitOfWork(PostgreSqlDbContext context)
        {
            _context = context;
        }

        public IRepository<Armazem> ArmazemRepository => _armazemRep ?? new Repository<Armazem>(_context);

        public IRepository<Categoria> CategoriaRepository => _categoriaRep ?? new Repository<Categoria>(_context);

        public IRepository<Contrato> ContratoRepository => _contratoRep ?? new Repository<Contrato>(_context);

        public IRepository<Fornecedor> FornecedorRepository => _fornecedorRep ?? new Repository<Fornecedor>(_context);

        public IRepository<ItemArmazem> ItemArmazemRepository => _itemArmazemRep ?? new Repository<ItemArmazem>(_context);

        public IRepository<ItemContrato> itemContratoRepository => _itemContratoRep ?? new Repository<ItemContrato>(_context);

        public IRepository<Produto> ProdutoRepository => _produtoRep ?? new Repository<Produto>(_context);

        public IRepository<Subcategoria> SubcategoriaRepository => _subcategoriaRep ?? new Repository<Subcategoria> (_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
