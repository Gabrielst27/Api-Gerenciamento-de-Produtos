using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProdutos.Models
{
    [Table("subcategorias")]
    public class Subcategoria
    {
        [Key]
        [Column("subcateg_id")]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "o codigo interno da subcategoria deve ter entre 1 e 30 caracteres", MinimumLength = 1)]
        [Column("subcateg_codinterno")]
        public string CodigoInterno { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "o nome da subcategoria deve ter entre 3 e 60 caracteres", MinimumLength = 3)]
        [Column("subcateg_nome")]
        public string Nome { get; set; }

        [Column("subcateg_data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("subcateg_categ_id")]
        public long CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }
    }
}