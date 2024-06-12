using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProdutos.Models
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        [Column("prod_id")]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "O codigo interno do produto deve ter entre 1 e 30 caracteres", MinimumLength = 1)]
        [Column("prod_codinterno")]
        public string CodigoInterno { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "O nome do produto deve ter entre 3 e 60 caracteres", MinimumLength = 3)]
        [Column("prod_nome")]
        public string Nome { get; set; }

        [StringLength(150, ErrorMessage = "A descricao do produto deve ter no maximo 150 caracteres")]
        [Column("prod_descricao")]
        public string Descricao { get; set; }

        [Column("prod_peso")]
        public float Peso { get; set; }

        [Column("prod_largura")]
        public float Lagura { get; set; }

        [Column("prod_comprimento")]
        public float Comprimento { get; set; }

        [Column("prod_altura")]
        public float Altura { get; set; }

        [StringLength(30, ErrorMessage = "A cor principal do produto deve ter entre 4 e 30 caracteres", MinimumLength = 4)]
        [Column("prod_cor_principal")]
        public string CorPrincipal { get; set; }

        [StringLength(30, ErrorMessage = "A cor secundaria do produto deve ter entre 4 e 30 caracteres", MinimumLength = 4)]
        [Column("prod_cor_secundaria")]
        public string CorSecundaria { get; set; }

        [Column("prod_data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Column("prod_preco_custo")]
        public decimal Custo { get; set; }

        [Required]
        [Column("prod_preco_min")]
        public decimal PrecoMin { get; set; }

        [Column("prod_estoque_total")]
        public decimal EstoqueTotal { get; set; }

        [Column("prod_categ_id")]
        public long CategoriaId { get; set; }

        [Column("prod_subcateg_id")]
        public long SubcategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

        public Subcategoria? Subcategoria { get; set; }
    }
}
