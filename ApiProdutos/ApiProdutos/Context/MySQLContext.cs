using ApiProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Produto>? Produtos { get; set; }
    }
}
