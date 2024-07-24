using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ApiProdutos.Enums;
using ApiProdutos.Models;
using System.Text.Json.Serialization;

namespace ApiProdutos.DTOs
{
    public class ContratoDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("contr_id")]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "O codigo interno do contrato deve ter entre 1 e 30 caracteres", MinimumLength = 1)]
        [Column("contr_codinterno")]
        public string CodigoInterno { get; set; }

        [Required]
        [Column("contr_valor_inicial")]
        public decimal ValorInicial { get; set; }

        [Required]
        [Column("contr_valor_mensal")]
        public decimal ValorMensal { get; set; }

        [Column("contr_reajuste")]
        public float Reajuste { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "O tipo do contrato deve ter entre 4 e 20 caracteres", MinimumLength = 4)]
        [Column("contr_tipo")]
        public string Tipo { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "O nome do representante do contrato deve ter entre 4 e 60 caracteres", MinimumLength = 4)]
        [Column("contr_representante")]
        public string Representante { get; set; }

        [Required]
        [Column("contr_dia_cobranca")]
        public DateTime DiaCobranca { get; set; }

        [Required]
        [Column("contr_data_expira")]
        public DateTime DataExpira { get; set; }

        [Required]
        [Column("contr_status")]
        public StatusContrato Status { get; set; }

        [Required]
        [Column("contr_emp_id")]
        public long FornecId { get; set; }

        [JsonIgnore]
        public Fornecedor? Fornec { get; set; }
    }
}
