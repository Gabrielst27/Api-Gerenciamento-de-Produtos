using ApiProdutos.DTOs;
using ApiProdutos.Models;

namespace ApiProdutos.Extensions.DTOs
{
    public static class ItemArmazemDTOMappingExtension
    {
        public static ItemArmazemDTO? ToDTO(this ItemArmazem itemArmazem)
        {
            if (itemArmazem is null) return null;

            return new ItemArmazemDTO()
            {
                Id = itemArmazem.Id,
                Armazem = itemArmazem.Armazem,
                Produto = itemArmazem.Produto,
                Quantidade = itemArmazem.Quantidade,
                ArmazemId = itemArmazem.ArmazemId,
                ProdutoId = itemArmazem.ProdutoId
            };
        }

        public static ItemArmazem? ToModel(this ItemArmazemDTO itemArmazemDto)
        {
            if (itemArmazemDto is null) return null;

            return new ItemArmazem()
            {
                Id = itemArmazemDto.Id,
                Armazem = itemArmazemDto.Armazem,
                Produto = itemArmazemDto.Produto,
                Quantidade = itemArmazemDto.Quantidade,
                ArmazemId = itemArmazemDto.ArmazemId,
                ProdutoId = itemArmazemDto.ProdutoId
            };
        }

        public static IEnumerable<ItemArmazemDTO>? ToListDTO(this IEnumerable<ItemArmazem> itemArmazens)
        {
            if (itemArmazens is null || !itemArmazens.Any())
            {
                return new List<ItemArmazemDTO>();
            }

            return itemArmazens.Select(itemArmazem => new ItemArmazemDTO
            {
                Id = itemArmazem.Id,
                Armazem = itemArmazem.Armazem,
                Produto = itemArmazem.Produto,
                Quantidade = itemArmazem.Quantidade,
                ArmazemId = itemArmazem.ArmazemId,
                ProdutoId = itemArmazem.ProdutoId
            });
        }
    }
}
