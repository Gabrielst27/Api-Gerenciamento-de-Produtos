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
            Produto prd = _digval.RemoverEspaco(produto);
            prd.Nome = _digval.PrimeiraMaiuscula(prd.Nome);
            prd.Descricao = _digval.PrimeiraMaiuscula(prd.Descricao);
            prd.CorPrincipal = _digval.PrimeiraMaiuscula(prd.CorPrincipal);
            prd.CorSecundaria = _digval.PrimeiraMaiuscula(prd.CorSecundaria);

            _uof.ProdutoRepository.Create(prd);
            _uof.Commit();

            return prd;
        }

        public Produto Update(Produto produto)
        {
            produto.Nome = _digval.PrimeiraMaiuscula(produto.Nome);
            produto.Descricao = _digval.PrimeiraMaiuscula(produto.Descricao);
            produto.CorPrincipal = _digval.PrimeiraMaiuscula(produto.CorPrincipal);
            produto.CorSecundaria = _digval.PrimeiraMaiuscula(produto.CorSecundaria);

            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();

            return produto;
        }

        public Produto Delete(long id)
        {
            _uof.ProdutoRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.ProdutoRepository.Get(p => p.Id == id);
        }
    }
}
