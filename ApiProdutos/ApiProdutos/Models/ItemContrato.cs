using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProdutos.Models
{

    [Table("item_contratos")]
    public class ItemContrato
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("contrprod_id")]
        public long Id { get; set; }

        [Required]
        [Column("contrprod_quant")]
        public int Quantidade { get; set; }

        [Required]
        [Column("contrprod_prod_id")]
        public long ProdutoId { get; set; }

        [Required]
        [Column("contrprod_contr_id")]
        public long ContrId { get; set; }

        [JsonIgnore]
        public Produto? Produto { get; set; }

        [JsonIgnore]
        public Fornecedor? Contr { get; set; }
    }
}
