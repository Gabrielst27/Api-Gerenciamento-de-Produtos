using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class SubcategoriaBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation<Subcategoria> _digval;

        public SubcategoriaBusiness(IUnitOfWork uof, IDigitacaoValidation<Subcategoria> digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public Subcategoria Get(long id)
        {
            return _uof.SubcategoriaRepository.Get(p => p.Id == id);
        }

        public IEnumerable<Subcategoria> GetAll()
        {
            return _uof.SubcategoriaRepository.GetAll();
        }

        public Subcategoria Create(Subcategoria subcategoria)
        {
            Subcategoria sbc = _digval.RemoverEspaco(subcategoria);
            sbc.Nome = _digval.PrimeiraMaiuscula(sbc.Nome);

            _uof.SubcategoriaRepository.Create(sbc);
            _uof.Commit();

            return sbc;
        }

        public Subcategoria Update(Subcategoria subcategoria)
        {
            subcategoria.Nome = _digval.PrimeiraMaiuscula(subcategoria.Nome);

            _uof.SubcategoriaRepository.Update(subcategoria);
            _uof.Commit();

            return subcategoria;
        }

        public Subcategoria Delete(long id)
        {
            _uof.SubcategoriaRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.SubcategoriaRepository.Get(p => p.Id == id);
        }
    }
}
