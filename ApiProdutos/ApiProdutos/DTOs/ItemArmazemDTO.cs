using ApiProdutos.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiProdutos.DTOs
{
    public class ItemArmazemDTO
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
