using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class ItemArmazemBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation<ItemArmazem> _digval;

        public ItemArmazemBusiness(IUnitOfWork uof, IDigitacaoValidation<ItemArmazem> digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public ItemArmazem Get(long id)
        {
            return _uof.ItemArmazemRepository.Get(p => p.Id == id);
        }

        public IEnumerable<ItemArmazem> GetAll()
        {
            return _uof.ItemArmazemRepository.GetAll();
        }

        public ItemArmazem Create(ItemArmazem itemArmazem)
        {
            _uof.ItemArmazemRepository.Create(itemArmazem);
            _uof.Commit();

            return itemArmazem;
        }

        public ItemArmazem Update(ItemArmazem itemArmazem)
        {
            _uof.ItemArmazemRepository.Update(itemArmazem);
            _uof.Commit();

            return itemArmazem;
        }

        public ItemArmazem Delete(long id)
        {
            _uof.ItemArmazemRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.ItemArmazemRepository.Get(p => p.Id == id);
        }
    }
}

