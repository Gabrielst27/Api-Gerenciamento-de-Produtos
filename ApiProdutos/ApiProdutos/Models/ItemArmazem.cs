using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProdutos.Models
{

    [Table("item_armazens")]
    public class ItemArmazem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [JsonIgnore]
        public Produto? Produto { get; set; }

        [JsonIgnore]
        public Armazem? Armazem { get; set; }
    }
}
