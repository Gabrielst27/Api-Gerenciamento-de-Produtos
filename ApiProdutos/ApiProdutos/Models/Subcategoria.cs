using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProdutos.Models
{
    [Table("subcategorias")]
    public class Subcategoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("subcateg_id")]
        public long Id { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "o nome da subcategoria deve ter entre 3 e 60 caracteres", MinimumLength = 3)]
        [Column("subcateg_nome")]
        public string Nome { get; set; }

        [Column("subcateg_data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Column("subcateg_categ_id")]
        public long CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

        [JsonIgnore]
        public List<Produto>? Produtos { get; set; }
    }
}