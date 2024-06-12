using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProdutos.Models
{

    [Table("lista_armazens_produtos")]
    public class ListaArmazemProduto
    {

        [Key]
        [Column("amzprod_id")]
        public long Id { get; set; }

        [Required]
        [Column("amzprod_prod_id")]
        public long ProdutoId { get; set; }

        [Required]
        [Column("amzprod_amz_id")]
        public long ArmazemId { get; set; }

        [Required]
        [Column("amzprod_quant")]
        public int Quantidade { get; set; }

        public Produto? Produto { get; set; }

        public Armazem? Armazem { get; set; }
    }
}
