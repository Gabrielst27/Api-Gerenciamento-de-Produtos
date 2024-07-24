using ApiProdutos.DTOs;
using ApiProdutos.Models;

namespace ApiProdutos.Extensions.DTOs
{
    public static class ContratoDTOMappingExtension
    {
        public static ContratoDTO? ToDTO(this Contrato contrato)
        {
            if (contrato is null) return null;

            return new ContratoDTO()
            {
                Id = contrato.Id,
                CodigoInterno = contrato.CodigoInterno,
                DiaCobranca = contrato.DiaCobranca,
                DataExpira = contrato.DataExpira,
                Fornec = contrato.Fornec,
                Reajuste = contrato.Reajuste,
                Representante = contrato.Representante,
                Status = contrato.Status,
                Tipo = contrato.Tipo,
                ValorInicial = contrato.ValorInicial,
                ValorMensal = contrato.ValorMensal,
                FornecId = contrato.FornecId,
            };
        }

        public static Contrato? ToModel(this ContratoDTO contratoDto)
        {
            if (contratoDto is null) return null;

            return new Contrato()
            {
                Id = contratoDto.Id,
                CodigoInterno = contratoDto.CodigoInterno,
                DiaCobranca = contratoDto.DiaCobranca,
                DataExpira = contratoDto.DataExpira,
                Fornec = contratoDto.Fornec,
                Reajuste = contratoDto.Reajuste,
                Representante = contratoDto.Representante,
                Status = contratoDto.Status,
                Tipo = contratoDto.Tipo,
                ValorInicial = contratoDto.ValorInicial,
                ValorMensal = contratoDto.ValorMensal,
                FornecId = contratoDto.FornecId,
            };
        }

        public static IEnumerable<ContratoDTO>? ToListDTO(this IEnumerable<Contrato> contratos)
        {
            if (contratos is null || !contratos.Any())
            {
                return new List<ContratoDTO>();
            }

            return contratos.Select(contrato => new ContratoDTO
            {
                Id = contrato.Id,
                CodigoInterno = contrato.CodigoInterno,
                DiaCobranca = contrato.DiaCobranca,
                DataExpira = contrato.DataExpira,
                Fornec = contrato.Fornec,
                Reajuste = contrato.Reajuste,
                Representante = contrato.Representante,
                Status = contrato.Status,
                Tipo = contrato.Tipo,
                ValorInicial = contrato.ValorInicial,
                ValorMensal = contrato.ValorMensal,
                FornecId = contrato.FornecId,
            });
        }
    }
}
