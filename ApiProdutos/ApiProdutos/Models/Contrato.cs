using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProdutos.Models
{
    [Table("contratos")]
    public class Contrato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("contr_id")]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "O codigo interno do contrato deve ter entre 1 e 30 caracteres", MinimumLength = 1)]
        [Column("contr_codint")]
        public string CodigoInterno { get; set; }

        [Required]
        [Column("contr_valor_inicial")]
        public decimal ValorInicial { get; set; }

        [Required]
        [Column("contr_valor_mensal")]
        public decimal ValorMensal { get; set; }

        [Column("contr_reajuste")]
        public decimal Reajuste { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "O tipo do contrato deve ter entre 4 e 20 caracteres", MinimumLength = 4)]
        [Column("contr_tipo")]
        public string Tipo { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "O nome do representante do contrato deve ter entre 4 e 60 caracteres", MinimumLength = 4)]
        [Column("contr_representante")]
        public string Representante { get; set; }

        [Column("contr_data_inicial")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Column("contr_dia_cobranca")]
        public DateTime DiaCobranca { get; set; }

        [Required]
        [Column("contr_data_expira")]
        public DateTime DataExpira { get; set; }

        [Required]
        [Column("contr_emp_id")]
        public long FornecId { get; set; }

        [JsonIgnore]
        public Fornecedor? Fornec { get; set; }
    }
}