using ApiProdutos.Business;
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
        private readonly FornecedorBusiness _business;

        public FornecedorController(FornecedorBusiness business)
        {
            _business = business;
        }

        [HttpGet("{id}")]
        public ActionResult<Fornecedor> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<Fornecedor> Post([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(fornecedor));
        }

        [HttpPut]
        public ActionResult<Fornecedor> Put([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(fornecedor));
        }

        [HttpDelete("{id}")]
        public ActionResult<Fornecedor> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Fornecedor não encontrado");
            
            return Ok(_business.Delete(id));
        }

    }
}
