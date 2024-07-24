using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApiProdutos.Models;
using System.Text.Json.Serialization;

namespace ApiProdutos.DTOs
{
    public class ArmazemDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("amz_id")]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "o nome do armazem deve ter entre 3 e ", MinimumLength = 3)]
        [Column("amz_nome")]
        public string Nome { get; set; }

        [JsonIgnore]
        public List<ItemArmazem>? ItemArmazem { get; set; }
    }
}
