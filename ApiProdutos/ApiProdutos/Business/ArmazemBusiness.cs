using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class ArmazemBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation _digval;

        public ArmazemBusiness(IUnitOfWork uof, IDigitacaoValidation digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public Armazem Get(long id)
        {
            return _uof.ArmazemRepository.Get(p => p.Id == id);
        }

        public IEnumerable<Armazem> GetAll()
        {
            return _uof.ArmazemRepository.GetAll();
        }

        public Armazem Create(Armazem armazem)
        {
            armazem.Nome = _digval.PrimeiraMaiuscula(armazem.Nome);

            _uof.ArmazemRepository.Create(armazem);
            _uof.Commit();

            return armazem;
        }

        public Armazem Update(Armazem armazem)
        {
            armazem.Nome = _digval.PrimeiraMaiuscula(armazem.Nome);

            _uof.ArmazemRepository.Update(armazem);
            _uof.Commit();

            return armazem;
        }

        public Armazem Delete(long id)
        {
            _uof.ArmazemRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.ArmazemRepository.Get(p => p.Id == id);
        }
    }
}
