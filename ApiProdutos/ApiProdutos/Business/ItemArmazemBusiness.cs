using ApiProdutos.DTOs;
using ApiProdutos.Extensions.DTOs;
using ApiProdutos.Models;
using ApiProdutos.Pagination;
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

        public ItemArmazemDTO Get(long id)
        {
            return _uof.ItemArmazemRepository.Get(p => p.Id == id).ToDTO();
        }

        public IEnumerable<ItemArmazemDTO> GetPag(GenericParameters genericParameters)
        {
            var itemArmazens = _uof.ItemArmazemRepository.GetPag(genericParameters);
            return itemArmazens.ToListDTO();
        }

        public IEnumerable<ItemArmazemDTO> GetAll()
        {
            return _uof.ItemArmazemRepository.GetAll().ToListDTO();
        }

        public ItemArmazemDTO Create(ItemArmazemDTO itemArmazemDto)
        {
            var itemArmazem = itemArmazemDto.ToModel();

            _uof.ItemArmazemRepository.Create(itemArmazem);
            _uof.Commit();

            return itemArmazem.ToDTO();
        }

        public ItemArmazemDTO Update(ItemArmazemDTO itemArmazemDto)
        {
            var itemArmazem = itemArmazemDto.ToModel();
            _uof.ItemArmazemRepository.Update(itemArmazem);
            _uof.Commit();

            return itemArmazem.ToDTO();
        }

        public ItemArmazemDTO Delete(long id)
        {
            _uof.ItemArmazemRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.ItemArmazemRepository.Get(p => p.Id == id).ToDTO();
        }
    }
}

