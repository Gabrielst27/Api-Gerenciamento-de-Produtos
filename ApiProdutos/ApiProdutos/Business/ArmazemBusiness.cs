using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class ArmazemBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation<Armazem> _digval;

        public ArmazemBusiness(IUnitOfWork uof, IDigitacaoValidation<Armazem> digval)
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
            Armazem amz = _digval.RemoverEspaco(armazem);
            amz.Nome = _digval.PrimeiraMaiuscula(amz.Nome);

            _uof.ArmazemRepository.Create(amz);
            _uof.Commit();

            return amz;
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
