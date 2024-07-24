using ApiProdutos.DTOs;
using ApiProdutos.Models;

namespace ApiProdutos.Extensions.DTOs
{
    public static class SubcategoriaDTOMappingExtension
    {
        public static SubcategoriaDTO? ToDTO(this Subcategoria subcategoria)
        {
            if (subcategoria is null) return null;

            return new SubcategoriaDTO()
            {
                Id = subcategoria.Id,
                Categoria = subcategoria.Categoria,
                Nome = subcategoria.Nome,
                Produtos = subcategoria.Produtos,
                CategoriaId = subcategoria.CategoriaId
            };
        }

        public static Subcategoria? ToModel(this SubcategoriaDTO subcategoriaDto)
        {
            if (subcategoriaDto is null) return null;

            return new Subcategoria()
            {
                Id = subcategoriaDto.Id,
                Categoria = subcategoriaDto.Categoria,
                Nome = subcategoriaDto.Nome,
                Produtos = subcategoriaDto.Produtos,
                CategoriaId = subcategoriaDto.CategoriaId
            };
        }

        public static IEnumerable<SubcategoriaDTO>? ToListDTO(this IEnumerable<Subcategoria> subcategorias)
        {
            if (subcategorias is null || !subcategorias.Any())
            {
                return new List<SubcategoriaDTO>();
            }

            return subcategorias.Select(subcategoria => new SubcategoriaDTO
            {
                Id = subcategoria.Id,
                Categoria = subcategoria.Categoria,
                Nome = subcategoria.Nome,
                Produtos = subcategoria.Produtos,
                CategoriaId = subcategoria.CategoriaId
            });
        }
    }
}
