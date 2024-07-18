﻿using ApiProdutos.Models;
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

        public Contrato Get(long id)
        {
            return _uof.ContratoRepository.Get(p => p.Id == id);
        }

        public IEnumerable<Contrato> GetAll()
        {
            return _uof.ContratoRepository.GetAll();
        }

        public Contrato Create(Contrato contrato)
        {
            Contrato ctr = _digval.RemoverEspaco(contrato);
            ctr.Representante = _digval.PrimeiraMaiuscula(ctr.Representante);

            _uof.ContratoRepository.Create(ctr);
            _uof.Commit();

            return ctr;
        }

        public Contrato Update(Contrato contrato)
        {
            contrato.Representante = _digval.PrimeiraMaiuscula(contrato.Representante);

            _uof.ContratoRepository.Update(contrato);
            _uof.Commit();

            return contrato;
        }

        public Contrato Delete(long id)
        {
            _uof.ContratoRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.ContratoRepository.Get(p => p.Id == id);
        }
    }
}
