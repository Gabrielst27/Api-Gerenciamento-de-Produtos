using ApiProdutos.DTOs;
using ApiProdutos.Extensions.DTOs;
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

        public ArmazemDTO Get(long id)
        {
            var armazem =  _uof.ArmazemRepository.Get(p => p.Id == id);
            return armazem.ToDTO();
        }

        public IEnumerable<ArmazemDTO> GetAll()
        {
            var armazem = _uof.ArmazemRepository.GetAll();
            return armazem.ToListDTO();
        }

        public ArmazemDTO Create(ArmazemDTO armazemDto)
        {
            DateTime time = DateTime.Now;

            var armazem = armazemDto.ToModel();

            Armazem amz = _digval.RemoverEspaco(armazem);
            amz.Nome = _digval.PrimeiraMaiuscula(amz.Nome);

            amz.DataCadastro = time.ToUniversalTime();

            _uof.ArmazemRepository.Create(amz);
            _uof.Commit();

            return amz.ToDTO();
        }

        public ArmazemDTO Update(ArmazemDTO armazemDto)
        {
            var armazem = armazemDto.ToModel();

            armazem.Nome = _digval.PrimeiraMaiuscula(armazem.Nome);

            _uof.ArmazemRepository.Update(armazem);
            _uof.Commit();

            return armazem.ToDTO();
        }

        public ArmazemDTO Delete(long id)
        {
            var armazem = _uof.ArmazemRepository.Get(a => a.Id == id);

            _uof.ArmazemRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return armazem.ToDTO();
        }
    }
}
