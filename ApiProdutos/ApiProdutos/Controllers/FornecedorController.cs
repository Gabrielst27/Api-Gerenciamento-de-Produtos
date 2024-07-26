using ApiProdutos.Business;
using ApiProdutos.DTOs;
using ApiProdutos.Models;
using ApiProdutos.Pagination;
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
        public ActionResult<FornecedorDTO> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<FornecedorDTO>> GetPag([FromQuery] GenericParameters genericParameters)
        {
            return Ok(_business.GetPag(genericParameters));
        }

        [HttpGet]
        public ActionResult<IEnumerable<FornecedorDTO>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<FornecedorDTO> Post([FromBody] FornecedorDTO fornecedor)
        {
            if (fornecedor is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(fornecedor));
        }

        [HttpPut]
        public ActionResult<FornecedorDTO> Put([FromBody] FornecedorDTO fornecedor)
        {
            if (fornecedor is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(fornecedor));
        }

        [HttpDelete("{id}")]
        public ActionResult<FornecedorDTO> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Fornecedor não encontrado");
            
            return Ok(_business.Delete(id));
        }

    }
}
