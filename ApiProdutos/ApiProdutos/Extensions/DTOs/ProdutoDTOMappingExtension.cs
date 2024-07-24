using ApiProdutos.DTOs;
using ApiProdutos.Models;

namespace ApiProdutos.Extensions.DTOs
{
    public static class ProdutoDTOMappingExtension
    {
        public static ProdutoDTO? ToDTO(this Produto produto)
        {
            if (produto is null) return null;

            return new ProdutoDTO()
            {
                Id = produto.Id,
                Altura = produto.Altura,
                Categoria = produto.Categoria,
                CodigoInterno = produto.CodigoInterno,
                Comprimento = produto.Comprimento,
                CorPrincipal = produto.CorPrincipal,
                CorSecundaria = produto.CorSecundaria,
                Custo = produto.Custo,
                Descricao = produto.Descricao,
                EstoqueTotal = produto.EstoqueTotal,
                ItemArmazem = produto.ItemArmazem,
                Largura = produto.Largura,
                Nome = produto.Nome,
                Peso = produto.Peso,
                PrecoMin = produto.PrecoMin,
                Subcategoria = produto.Subcategoria,
                CategoriaId = produto.CategoriaId,
                SubcategoriaId = produto.SubcategoriaId
            };
        }

        public static Produto? ToModel(this ProdutoDTO produtoDto)
        {
            if (produtoDto is null) return null;

            return new Produto()
            {
                Id = produtoDto.Id,
                Altura = produtoDto.Altura,
                Categoria = produtoDto.Categoria,
                CodigoInterno = produtoDto.CodigoInterno,
                Comprimento = produtoDto.Comprimento,
                CorPrincipal = produtoDto.CorPrincipal,
                CorSecundaria = produtoDto.CorSecundaria,
                Custo = produtoDto.Custo,
                Descricao = produtoDto.Descricao,
                EstoqueTotal = produtoDto.EstoqueTotal,
                ItemArmazem = produtoDto.ItemArmazem,
                Largura = produtoDto.Largura,
                Nome = produtoDto.Nome,
                Peso = produtoDto.Peso,
                PrecoMin = produtoDto.PrecoMin,
                Subcategoria = produtoDto.Subcategoria,
                CategoriaId = produtoDto.CategoriaId,
                SubcategoriaId = produtoDto.SubcategoriaId
            };
        }

        public static IEnumerable<ProdutoDTO>? ToListDTO(this IEnumerable<Produto> produtos)
        {
            if (produtos is null || !produtos.Any())
            {
                return new List<ProdutoDTO>();
            }

            return produtos.Select(produto => new ProdutoDTO
            {
                Id = produto.Id,
                Altura = produto.Altura,
                Categoria = produto.Categoria,
                CodigoInterno = produto.CodigoInterno,
                Comprimento = produto.Comprimento,
                CorPrincipal = produto.CorPrincipal,
                CorSecundaria = produto.CorSecundaria,
                Custo = produto.Custo,
                Descricao = produto.Descricao,
                EstoqueTotal = produto.EstoqueTotal,
                ItemArmazem = produto.ItemArmazem,
                Largura = produto.Largura,
                Nome = produto.Nome,
                Peso = produto.Peso,
                PrecoMin = produto.PrecoMin,
                Subcategoria = produto.Subcategoria,
                CategoriaId = produto.CategoriaId,
                SubcategoriaId = produto.SubcategoriaId
            });
        }
    }
}
