using ApiProdutos.DTOs;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class CategoriaBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation<Categoria> _digval;

        public CategoriaBusiness(IUnitOfWork uof, IDigitacaoValidation<Categoria> digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public CategoriaDTO Get(long id)
        {
            var categoria = _uof.CategoriaRepository.Get(p => p.Id == id);
            var categoriaDto = new CategoriaDTO()
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Reajuste1 = categoria.Reajuste1,
                Reajuste2 = categoria.Reajuste2,
                Reajuste3 = categoria.Reajuste3,
                Produtos = categoria.Produtos,
                Subcategorias = categoria.Subcategorias
            };

            return categoriaDto;
            
        }

        public IEnumerable<CategoriaDTO> GetAll()
        {
            var categorias = _uof.CategoriaRepository.GetAll();

            var categoriasDto = new List<CategoriaDTO>();
            foreach (var categoria in categorias)
            {
                categoriasDto.Add(new CategoriaDTO()
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

            return categoriasDto;
        }

        public CategoriaDTO Create(CategoriaDTO categoriaDto)
        {
            DateTime time = DateTime.Now;

            var categoria = new Categoria()
            {
                Id = categoriaDto.Id,
                Nome = categoriaDto.Nome,
                Reajuste1 = categoriaDto.Reajuste1,
                Reajuste2 = categoriaDto.Reajuste2,
                Reajuste3 = categoriaDto.Reajuste3,
                DataCadastro = time.ToUniversalTime(),
                Produtos = categoriaDto.Produtos,
                Subcategorias = categoriaDto.Subcategorias
            };

            Categoria cat = _digval.RemoverEspaco(categoria);
            cat.Nome = _digval.PrimeiraMaiuscula(categoria.Nome);

            _uof.CategoriaRepository.Create(cat);
            _uof.Commit();

            var catDto = new CategoriaDTO()
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Reajuste1 = categoria.Reajuste1,
                Reajuste2 = categoria.Reajuste2,
                Reajuste3 = categoria.Reajuste3,
                Produtos = categoria.Produtos,
                Subcategorias = categoria.Subcategorias
            };

            return catDto;
        }

        public CategoriaDTO Update(CategoriaDTO categoriaDto)
        {
            var categoria = new Categoria()
            {
                Id = categoriaDto.Id,
                Nome = categoriaDto.Nome,
                Reajuste1 = categoriaDto.Reajuste1,
                Reajuste2 = categoriaDto.Reajuste2,
                Reajuste3 = categoriaDto.Reajuste3,
                Produtos = categoriaDto.Produtos,
                Subcategorias = categoriaDto.Subcategorias
            };

            categoria.Nome = _digval.PrimeiraMaiuscula(categoria.Nome);

            _uof.CategoriaRepository.Update(categoria);
            _uof.Commit();

            var catDto = new CategoriaDTO()
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Reajuste1 = categoria.Reajuste1,
                Reajuste2 = categoria.Reajuste2,
                Reajuste3 = categoria.Reajuste3,
                Produtos = categoria.Produtos,
                Subcategorias = categoria.Subcategorias
            };

            return catDto;
        }

        public CategoriaDTO Delete(long id)
        {
            var categoria = _uof.CategoriaRepository.Get(p => p.Id == id);

            _uof.CategoriaRepository.Delete(p => p.Id == id);
            _uof.Commit();

            var catDto = new CategoriaDTO()
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Reajuste1 = categoria.Reajuste1,
                Reajuste2 = categoria.Reajuste2,
                Reajuste3 = categoria.Reajuste3,
                Produtos = categoria.Produtos,
                Subcategorias = categoria.Subcategorias
            };

            return catDto;
        }
    }
}
