using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProdutos.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Custo { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
    }
}
