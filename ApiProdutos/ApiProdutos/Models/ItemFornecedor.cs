using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProdutos.Models
{

    [Table("item_fornecedores")]
    public class ItemFornecedor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("fornecprod_id")]
        public long Id { get; set; }

        [Required]
        [Column("fornecprod_quant")]
        public int Quantidade { get; set; }

        [Required]
        [Column("fornecprod_prod_id")]
        public long ProdutoId { get; set; }

        [Required]
        [Column("fornecprod_fornec_id")]
        public long FornecId { get; set; }

        [JsonIgnore]
        public Produto? Produto { get; set; }

        [JsonIgnore]
        public Fornecedor? Fornec { get; set; }
    }
}
