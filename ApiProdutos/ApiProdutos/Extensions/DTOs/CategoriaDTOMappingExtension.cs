using ApiProdutos.DTOs;
using ApiProdutos.Models;

namespace ApiProdutos.Extensions.DTOs
{
    public static class CategoriaDTOMappingExtension
    {
        public static CategoriaDTO? ToDTO(this Categoria categoria)
        {
            if (categoria is null) return null;

            return new CategoriaDTO()
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Reajuste1 = categoria.Reajuste1,
                Reajuste2 = categoria.Reajuste2,
                Reajuste3 = categoria.Reajuste3,
                Produtos = categoria.Produtos,
                Subcategorias = categoria.Subcategorias
            };
        }

        public static Categoria? ToModel(this CategoriaDTO categoriaDto)
        {
            if (categoriaDto is null) return null;

            return new Categoria()
            {
                Id = categoriaDto.Id,
                Nome = categoriaDto.Nome,
                Reajuste1 = categoriaDto.Reajuste1,
                Reajuste2 = categoriaDto.Reajuste2,
                Reajuste3 = categoriaDto.Reajuste3,
                Produtos = categoriaDto.Produtos,
                Subcategorias = categoriaDto.Subcategorias
            };
        }

        public static IEnumerable<CategoriaDTO>? ToListDTO(this IEnumerable<Categoria> categorias)
        {
            if (categorias is null || !categorias.Any())
            {
                return new List<CategoriaDTO>();
            }

            return categorias.Select(categoria => new CategoriaDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Reajuste1 = categoria.Reajuste1,
                Reajuste2 = categoria.Reajuste2,
                Reajuste3 = categoria.Reajuste3,
                Produtos = categoria.Produtos,
                Subcategorias = categoria.Subcategorias
            });
        }
    }
}
