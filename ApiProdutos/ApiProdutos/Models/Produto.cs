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

        [Column("prod_codinterno")]
        public string CodigoInterno { get; set; }

        [Column("prod_nome")]
        public string Nome { get; set; }

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

        [Column("prod_cor_principal")]
        public string CorPrincipal { get; set; }

        [Column("prod_cor_secundaria")]
        public string CorSecundaria { get; set; }

        [Column("prod_data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("prod_preco_custo")]
        public decimal Custo { get; set; }

        [Column("prod_preco_min")]
        public decimal PrecoMin { get; set; }

    }
}
