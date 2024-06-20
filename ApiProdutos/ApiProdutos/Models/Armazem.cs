using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProdutos.Models
{

    [Table("armazens")]
    public class Armazem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("amz_id")]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "o nome do armazem deve ter entre 3 e ", MinimumLength = 3)]
        [Column("amz_nome")]
        public string Nome { get; set; }

        [Column("amz_data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonIgnore]
        public List<ItemArmazem>? ItemArmazem { get; set; }
    }
}
