﻿using ApiProdutos.Enums;
using ApiProdutos.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiProdutos.DTOs
{
    public class FornecedorDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("fornec_id")]
        public long Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "O codigo interno deve ter entre 1 e 30 caracteres", MinimumLength = 1)]
        [Column("fornec_codinterno")]
        public string Codinterno { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "O cnpj deve ter 14 caracteres, somente numeros")]
        [Column("fornec_cnpj")]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "A razao social deve ter entre 3 e 60 caracteres", MinimumLength = 3)]
        [Column("fornec_razao_social")]
        public string RazaoSocial { get; set; }

        [StringLength(60, ErrorMessage = "A fantasia deve ter entre 3 e 60 caracteres", MinimumLength = 3)]
        [Column("fornec_fantasia")]
        public string Fantasia { get; set; }

        [Required]
        [Column("fornec_status")]
        public StatusFornecedor Status { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "O CEP deve ter 8 caracteres")]
        [Column("fornec_cep")]
        public string Cep { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "O logradouro deve ter até 60 caracteres", MinimumLength = 1)]
        [Column("fornec_logradouro")]
        public string Logradouro { get; set; }

        [Required]
        [Column("fornec_numero")]
        public int Numero { get; set; }

        [StringLength(60, ErrorMessage = "O complemento deve ter até 60 caracteres")]
        [Column("fornec_complemento")]
        public string Complemento { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "O bairro deve ter até 60 caracteres", MinimumLength = 1)]
        [Column("fornec_bairro")]
        public string Bairro { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "A cidade deve ter até 40 caracteres", MinimumLength = 1)]
        [Column("fornec_cidade")]
        public string Cidade { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "O UF deve ter até 4 caracteres", MinimumLength = 1)]
        [Column("fornec_uf")]
        public string Uf { get; set; }

        [Required]
        [StringLength(56, ErrorMessage = "O pais deve ter até 56 caracteres", MinimumLength = 1)]
        [Column("fornec_pais")]
        public string Pais { get; set; }

        [Required]
        [Column("fornec_tel1")]
        public long Telefone1 { get; set; }

        [Column("fornec_tel2")]
        public long Telefone2 { get; set; }

        [Column("fornec_tel3")]
        public long Telefone3 { get; set; }

        [Column("fornec_email")]
        public string? Email { get; set; }

        [JsonIgnore]
        public List<Contrato>? Contratos { get; set; }
    }
}
