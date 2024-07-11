using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public FornecedorController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public ActionResult<Fornecedor> Get([FromRoute] long id)
        {
            var fornecedor = _uof.FornecedorRepository.Get(p => p.Id == id);
            return Ok(fornecedor);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> GetAll()
        {
            return Ok(_uof.FornecedorRepository.GetAll());
        }

        [HttpPost]
        public ActionResult<Fornecedor> Post([FromBody] Fornecedor fornecedor)
        {
            fornecedor.RazaoSocial = PrimeiraMaiuscula.Corrigir(fornecedor.RazaoSocial);
            fornecedor.Fantasia = PrimeiraMaiuscula.Corrigir(fornecedor.Fantasia);
            fornecedor.Logradouro = PrimeiraMaiuscula.Corrigir(fornecedor.Logradouro);
            fornecedor.Bairro = PrimeiraMaiuscula.Corrigir(fornecedor.Bairro);
            fornecedor.Complemento = PrimeiraMaiuscula.Corrigir(fornecedor.Complemento);
            fornecedor.Cidade = PrimeiraMaiuscula.Corrigir(fornecedor.Cidade);
            fornecedor.Uf = fornecedor.Uf.ToUpper();
            fornecedor.Pais = PrimeiraMaiuscula.Corrigir(fornecedor.Pais);

            if (fornecedor is null) return BadRequest("Dados inválidos");

            _uof.FornecedorRepository.Create(fornecedor);
            _uof.Commit();
            return Ok(fornecedor);
        }

        [HttpPut]
        public ActionResult<Fornecedor> Put([FromBody] Fornecedor fornecedor)
        {
            fornecedor.RazaoSocial = PrimeiraMaiuscula.Corrigir(fornecedor.RazaoSocial);
            fornecedor.Fantasia = PrimeiraMaiuscula.Corrigir(fornecedor.Fantasia);
            fornecedor.Logradouro = PrimeiraMaiuscula.Corrigir(fornecedor.Logradouro);
            fornecedor.Bairro = PrimeiraMaiuscula.Corrigir(fornecedor.Bairro);
            fornecedor.Complemento = PrimeiraMaiuscula.Corrigir(fornecedor.Complemento);
            fornecedor.Cidade = PrimeiraMaiuscula.Corrigir(fornecedor.Cidade);
            fornecedor.Uf.ToUpper();
            fornecedor.Pais = PrimeiraMaiuscula.Corrigir(fornecedor.Pais);

            if (fornecedor is null) return BadRequest("Dados inválidos");

            _uof.FornecedorRepository.Update(fornecedor);
            _uof.Commit();
            return Ok(fornecedor);
        }

        [HttpDelete("{id}")]
        public ActionResult<Fornecedor> Delete([FromRoute] long id)
        {
            var fornecedor = _uof.FornecedorRepository.Get(p => p.Id == id);
            _uof.FornecedorRepository.Delete(p => p.Id == id);
            _uof.Commit();
            return Ok(fornecedor);
        }

    }
}
