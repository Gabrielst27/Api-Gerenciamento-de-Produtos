using ApiProdutos.DTOs;
using ApiProdutos.Extensions.DTOs;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class ContratoBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation<Contrato> _digval;

        public ContratoBusiness(IUnitOfWork uof, IDigitacaoValidation<Contrato> digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public ContratoDTO Get(long id)
        {
            return _uof.ContratoRepository.Get(p => p.Id == id).ToDTO();
        }

        public IEnumerable<ContratoDTO> GetAll()
        {
            return _uof.ContratoRepository.GetAll().ToListDTO();
        }

        public ContratoDTO Create(ContratoDTO contratoDto)
        {
            DateTime time = DateTime.Now;

            var contrato = contratoDto.ToModel();
            Contrato ctr = _digval.RemoverEspaco(contrato);
            ctr.Representante = _digval.PrimeiraMaiuscula(ctr.Representante);

            contrato.DataCadastro = time.ToUniversalTime();

            _uof.ContratoRepository.Create(ctr);
            _uof.Commit();

            return ctr.ToDTO();
        }

        public ContratoDTO Update(ContratoDTO contratoDto)
        {
            var contrato = contratoDto.ToModel();
            contrato.Representante = _digval.PrimeiraMaiuscula(contrato.Representante);

            _uof.ContratoRepository.Update(contrato);
            _uof.Commit();

            return contrato.ToDTO();
        }

        public ContratoDTO Delete(long id)
        {
            _uof.ContratoRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.ContratoRepository.Get(p => p.Id == id).ToDTO();
        }
    }
}
