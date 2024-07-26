using ApiProdutos.DTOs;
using ApiProdutos.Extensions.DTOs;
using ApiProdutos.Models;
using ApiProdutos.Pagination;
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
            return categoria.ToDTO();
            
        }

        public IEnumerable<CategoriaDTO> GetPag(GenericParameters genericParameters)
        {
            var categorias = _uof.CategoriaRepository.GetPag(genericParameters);
            return categorias.ToListDTO();
        }

        public IEnumerable<CategoriaDTO> GetAll()
        {
            var categorias = _uof.CategoriaRepository.GetAll();
            return categorias.ToListDTO();
        }

        public CategoriaDTO Create(CategoriaDTO categoriaDto)
        {
            DateTime time = DateTime.Now;

            var categoria = categoriaDto.ToModel();

            Categoria cat = _digval.RemoverEspaco(categoria);
            cat.Nome = _digval.PrimeiraMaiuscula(categoria.Nome);

            cat.DataCadastro = time.ToUniversalTime();

            _uof.CategoriaRepository.Create(cat);
            _uof.Commit();

            return cat.ToDTO();
        }

        public CategoriaDTO Update(CategoriaDTO categoriaDto)
        {
            var categoria = categoriaDto.ToModel();

            categoria.Nome = _digval.PrimeiraMaiuscula(categoria.Nome);

            _uof.CategoriaRepository.Update(categoria);
            _uof.Commit();

            return categoria.ToDTO();
        }

        public CategoriaDTO Delete(long id)
        {
            var categoria = _uof.CategoriaRepository.Get(p => p.Id == id);

            _uof.CategoriaRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return categoria.ToDTO();
        }
    }
}
