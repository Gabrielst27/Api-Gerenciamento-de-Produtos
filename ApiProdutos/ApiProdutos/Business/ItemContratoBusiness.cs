using ApiProdutos.DTOs;
using ApiProdutos.Extensions.DTOs;
using ApiProdutos.Models;
using ApiProdutos.Pagination;
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

        public ItemContratoDTO Get(long id)
        {
            return _uof.ItemContratoRepository.Get(p => p.Id == id).ToDTO();
        }

        public IEnumerable<ItemContratoDTO> GetPag(GenericParameters genericParameters)
        {
            var itemContratos = _uof.ItemContratoRepository.GetPag(genericParameters);
            return itemContratos.ToListDTO();
        }

        public IEnumerable<ItemContratoDTO> GetAll()
        {
            return _uof.ItemContratoRepository.GetAll().ToListDTO();
        }

        public ItemContratoDTO Create(ItemContratoDTO itemContratoDto)
        {
            var itemContrato = itemContratoDto.ToModel();

            _uof.ItemContratoRepository.Create(itemContrato);
            _uof.Commit();

            return itemContrato.ToDTO();
        }

        public ItemContratoDTO Update(ItemContratoDTO itemContratoDto)
        {
            var itemContrato = itemContratoDto.ToModel();

            _uof.ItemContratoRepository.Update(itemContrato);
            _uof.Commit();

            return itemContrato.ToDTO();
        }

        public ItemContratoDTO Delete(long id)
        {
            _uof.ItemContratoRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.ItemContratoRepository.Get(p => p.Id == id).ToDTO();
        }
    }
}
