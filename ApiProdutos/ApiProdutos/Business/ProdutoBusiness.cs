﻿using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class ProdutoBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation _digval;

        public ProdutoBusiness(IUnitOfWork uof, IDigitacaoValidation digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public Produto Get(long id)
        {
            return _uof.ProdutoRepository.Get(p => p.Id == id);
        }
        
        public IEnumerable<Produto> GetAll()
        {
            return _uof.ProdutoRepository.GetAll();
        }

        public Produto Create(Produto produto)
        {
            produto.Nome = _digval.PrimeiraMaiuscula(produto.Nome);
            produto.Descricao = _digval.PrimeiraMaiuscula(produto.Descricao);

            _uof.ProdutoRepository.Create(produto);
            _uof.Commit();

            return produto;
        }

        public Produto Update(Produto produto)
        {
            produto.Nome = _digval.PrimeiraMaiuscula(produto.Nome);
            produto.Descricao = _digval.PrimeiraMaiuscula(produto.Descricao);

            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();

            return produto;
        }

        public Produto Delete(long id)
        {
            var prod = _uof.ProdutoRepository.Get(p => p.Id == id);

            _uof.ProdutoRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return prod;
        }
    }
}
