using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProdutos.Models
{

    [Table("armazens")]
    public class Armazem
    {
        [Key]
        [Column("amz_id")]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "o nome do armazem deve ter entre 3 e ", MinimumLength = 3)]
        [Column("amz_nome")]
        public string Nome { get; set; }

        [Column("amz_nome")]
        public DateTime DataCadastro { get; set; }
    }
}
