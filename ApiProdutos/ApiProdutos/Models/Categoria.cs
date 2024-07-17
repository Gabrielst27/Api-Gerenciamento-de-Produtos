using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProdutos.Models
{
    [Table("categorias")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("categ_id")]
        public long Id { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "O nome da categoria deve ter entre 3 e 60 caracteres", MinimumLength = 3)]
        [Column("categ_nome")]
        public string Nome { get; set; }

        [Column("categ_reajuste1")]
        public float Reajuste1 { get; set; }

        [Column("categ_reajuste2")]
        public float Reajuste2 { get; set; }

        [Column("categ_reajuste3")]
        public float Reajuste3 { get; set; }

        [Column("categ_data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonIgnore]
        public List<Subcategoria>? Subcategorias { get; set; }

        [JsonIgnore]
        public List<Produto>? Produtos { get; set; }
    }
}