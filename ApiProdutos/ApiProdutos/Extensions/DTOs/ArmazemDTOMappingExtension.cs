using ApiProdutos.DTOs;
using ApiProdutos.Models;

namespace ApiProdutos.Extensions.DTOs
{
    public static class ArmazemDTOMappingExtension
    {
        public static ArmazemDTO? ToDTO(this Armazem armazem)
        {
            if (armazem is null) return null;

            return new ArmazemDTO()
            {
                Id = armazem.Id,
                Nome = armazem.Nome,
                ItemArmazem = armazem.ItemArmazem
            };
        }

        public static Armazem? ToModel(this ArmazemDTO armazemDto)
        {
            if (armazemDto is null) return null;

            return new Armazem()
            {
                Id = armazemDto.Id,
                Nome = armazemDto.Nome,
                ItemArmazem = armazemDto.ItemArmazem
            };
        }

        public static IEnumerable<ArmazemDTO>? ToListDTO(this IEnumerable<Armazem> armazens)
        {
            if (armazens is null || !armazens.Any())
            {
                return new List<ArmazemDTO>();
            }

            return armazens.Select(armazem => new ArmazemDTO
            {
                Id = armazem.Id,
                Nome = armazem.Nome,
                ItemArmazem = armazem.ItemArmazem
            });
        }
    }
}
