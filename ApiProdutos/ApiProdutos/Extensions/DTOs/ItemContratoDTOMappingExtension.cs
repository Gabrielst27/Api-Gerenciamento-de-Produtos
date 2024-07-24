using ApiProdutos.DTOs;
using ApiProdutos.Models;

namespace ApiProdutos.Extensions.DTOs
{
    public static class ItemContratoDTOMappingExtension
    {
        public static ItemContratoDTO? ToDTO(this ItemContrato itemContrato)
        {
            if (itemContrato is null) return null;

            return new ItemContratoDTO()
            {
                Id = itemContrato.Id,
                Contr = itemContrato.Contr,
                Produto = itemContrato.Produto,
                Quantidade = itemContrato.Quantidade,
                ContrId = itemContrato.ContrId,
                ProdutoId = itemContrato.ProdutoId
            };
        }

        public static ItemContrato? ToModel(this ItemContratoDTO itemContratoDto)
        {
            if (itemContratoDto is null) return null;

            return new ItemContrato()
            {
                Id = itemContratoDto.Id,
                Contr = itemContratoDto.Contr,
                Produto = itemContratoDto.Produto,
                Quantidade = itemContratoDto.Quantidade,
                ContrId = itemContratoDto.ContrId,
                ProdutoId = itemContratoDto.ProdutoId,
            };
        }

        public static IEnumerable<ItemContratoDTO>? ToListDTO(this IEnumerable<ItemContrato> itemContratos)
        {
            if (itemContratos is null || !itemContratos.Any())
            {
                return new List<ItemContratoDTO>();
            }

            return itemContratos.Select(itemContrato => new ItemContratoDTO
            {
                Id = itemContrato.Id,
                Contr = itemContrato.Contr,
                Produto = itemContrato.Produto,
                Quantidade = itemContrato.Quantidade,
                ContrId = itemContrato.ContrId,
                ProdutoId = itemContrato.ProdutoId
            });
        }
    }
}
