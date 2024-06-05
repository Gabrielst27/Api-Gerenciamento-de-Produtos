using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProdutos.Models
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("custo")]
        public decimal Custo { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }

        [Column("imagemurl")]
        public string ImagemUrl { get; set; }
    }
}
