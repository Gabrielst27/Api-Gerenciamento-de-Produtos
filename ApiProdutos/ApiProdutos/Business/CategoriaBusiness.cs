using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class CategoriaBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation _digval;

        public CategoriaBusiness(IUnitOfWork uof, IDigitacaoValidation digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public Categoria Get(long id)
        {
            return _uof.CategoriaRepository.Get(p => p.Id == id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _uof.CategoriaRepository.GetAll();
        }

        public Categoria Create(Categoria categoria)
        {
            categoria.Nome = _digval.PrimeiraMaiuscula(categoria.Nome);

            _uof.CategoriaRepository.Create(categoria);
            _uof.Commit();

            return categoria;
        }

        public Categoria Update(Categoria categoria)
        {
            categoria.Nome = _digval.PrimeiraMaiuscula(categoria.Nome);

            _uof.CategoriaRepository.Update(categoria);
            _uof.Commit();

            return categoria;
        }

        public Categoria Delete(long id)
        {
            _uof.CategoriaRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.CategoriaRepository.Get(p => p.Id == id);
        }
    }
}
