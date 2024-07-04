using ApiProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Context
{
    public class PostgreSqlDbContext : DbContext
    {
        public PostgreSqlDbContext(DbContextOptions<PostgreSqlDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }
        public DbSet<Armazem> Armazens { get; set; }
        public DbSet<ItemArmazem> ItensAmzProd { get; set;}
        public DbSet<ItemContrato> ItemContratos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
    }
}
