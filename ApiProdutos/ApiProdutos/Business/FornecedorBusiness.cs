﻿using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class FornecedorBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation<Fornecedor> _digval;

        public FornecedorBusiness(IUnitOfWork uof, IDigitacaoValidation<Fornecedor> digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public Fornecedor Get(long id)
        {
            return _uof.FornecedorRepository.Get(p => p.Id == id);
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            return _uof.FornecedorRepository.GetAll();
        }

        public Fornecedor Create(Fornecedor fornecedor)
        {
            Fornecedor fnc = _digval.RemoverEspaco(fornecedor);
            fnc.RazaoSocial = _digval.PrimeiraMaiuscula(fnc.RazaoSocial);
            fnc.Fantasia = _digval.PrimeiraMaiuscula(fnc.Fantasia);
            fnc.Logradouro = _digval.PrimeiraMaiuscula(fnc.Logradouro);
            fnc.Complemento = _digval.PrimeiraMaiuscula(fnc.Complemento);
            fnc.Bairro = _digval.PrimeiraMaiuscula(fnc.Bairro);
            fnc.Cidade = _digval.PrimeiraMaiuscula(fnc.Cidade);
            fnc.Uf = fnc.Uf.ToUpper();
            fnc.Pais = _digval.PrimeiraMaiuscula(fnc.Pais);

            _uof.FornecedorRepository.Create(fnc);
            _uof.Commit();

            return fnc;
        }

        public Fornecedor Update(Fornecedor fornecedor)
        {
            fornecedor.RazaoSocial = _digval.PrimeiraMaiuscula(fornecedor.RazaoSocial);
            fornecedor.Fantasia = _digval.PrimeiraMaiuscula(fornecedor.Fantasia);
            fornecedor.Logradouro = _digval.PrimeiraMaiuscula(fornecedor.Logradouro);
            fornecedor.Complemento = _digval.PrimeiraMaiuscula(fornecedor.Complemento);
            fornecedor.Bairro = _digval.PrimeiraMaiuscula(fornecedor.Bairro);
            fornecedor.Cidade = _digval.PrimeiraMaiuscula(fornecedor.Cidade);
            fornecedor.Uf = fornecedor.Uf.ToUpper();
            fornecedor.Pais = _digval.PrimeiraMaiuscula(fornecedor.Pais);

            _uof.FornecedorRepository.Update(fornecedor);
            _uof.Commit();

            return fornecedor;
        }

        public Fornecedor Delete(long id)
        {
            _uof.FornecedorRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.FornecedorRepository.Get(p => p.Id == id);
        }
    }
}
