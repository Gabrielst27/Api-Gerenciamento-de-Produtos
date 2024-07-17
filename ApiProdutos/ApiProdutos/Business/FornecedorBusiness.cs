using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class FornecedorBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation _digval;

        public FornecedorBusiness(IUnitOfWork uof, IDigitacaoValidation digval)
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
            fornecedor.RazaoSocial = _digval.PrimeiraMaiuscula(fornecedor.RazaoSocial);
            fornecedor.Fantasia = _digval.PrimeiraMaiuscula(fornecedor.Fantasia);
            fornecedor.Logradouro = _digval.PrimeiraMaiuscula(fornecedor.Logradouro);
            fornecedor.Complemento = _digval.PrimeiraMaiuscula(fornecedor.Complemento);
            fornecedor.Bairro = _digval.PrimeiraMaiuscula(fornecedor.Bairro);
            fornecedor.Cidade = _digval.PrimeiraMaiuscula(fornecedor.Cidade);
            fornecedor.Uf = fornecedor.Uf.ToUpper();
            fornecedor.Pais = _digval.PrimeiraMaiuscula(fornecedor.Pais);

            _uof.FornecedorRepository.Create(fornecedor);
            _uof.Commit();

            return fornecedor;
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
