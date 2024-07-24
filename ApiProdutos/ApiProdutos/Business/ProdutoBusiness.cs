using ApiProdutos.DTOs;
using ApiProdutos.Extensions.DTOs;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class ProdutoBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation<Produto> _digval;

        public ProdutoBusiness(IUnitOfWork uof, IDigitacaoValidation<Produto> digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public ProdutoDTO Get(long id)
        {
            return _uof.ProdutoRepository.Get(p => p.Id == id).ToDTO();
        }
        
        public IEnumerable<ProdutoDTO> GetAll()
        {
            return _uof.ProdutoRepository.GetAll().ToListDTO();
        }

        public ProdutoDTO Create(ProdutoDTO produtoDto)
        {
            DateTime time = DateTime.Now;

            var produto = produtoDto.ToModel();

            Produto prd = _digval.RemoverEspaco(produto);
            prd.Nome = _digval.PrimeiraMaiuscula(prd.Nome);
            prd.Descricao = _digval.PrimeiraMaiuscula(prd.Descricao);
            prd.CorPrincipal = _digval.PrimeiraMaiuscula(prd.CorPrincipal);
            prd.CorSecundaria = _digval.PrimeiraMaiuscula(prd.CorSecundaria);

            prd.DataCadastro = time.ToUniversalTime();

            _uof.ProdutoRepository.Create(prd);
            _uof.Commit();

            return prd.ToDTO();
        }

        public ProdutoDTO Update(ProdutoDTO produtoDto)
        {
            var produto = produtoDto.ToModel();

            produto.Nome = _digval.PrimeiraMaiuscula(produto.Nome);
            produto.Descricao = _digval.PrimeiraMaiuscula(produto.Descricao);
            produto.CorPrincipal = _digval.PrimeiraMaiuscula(produto.CorPrincipal);
            produto.CorSecundaria = _digval.PrimeiraMaiuscula(produto.CorSecundaria);

            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();

            return produto.ToDTO();
        }

        public ProdutoDTO Delete(long id)
        {
            _uof.ProdutoRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.ProdutoRepository.Get(p => p.Id == id).ToDTO();
        }
    }
}
