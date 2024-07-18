using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class ItemContratoBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation<ItemContrato> _digval;

        public ItemContratoBusiness(IUnitOfWork uof, IDigitacaoValidation<ItemContrato> digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public ItemContrato Get(long id)
        {
            return _uof.ItemContratoRepository.Get(p => p.Id == id);
        }

        public IEnumerable<ItemContrato> GetAll()
        {
            return _uof.ItemContratoRepository.GetAll();
        }

        public ItemContrato Create(ItemContrato itemContrato)
        {
            _uof.ItemContratoRepository.Create(itemContrato);
            _uof.Commit();

            return itemContrato;
        }

        public ItemContrato Update(ItemContrato itemContrato)
        {
            _uof.ItemContratoRepository.Update(itemContrato);
            _uof.Commit();

            return itemContrato;
        }

        public ItemContrato Delete(long id)
        {
            _uof.ItemContratoRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.ItemContratoRepository.Get(p => p.Id == id);
        }
    }
}
