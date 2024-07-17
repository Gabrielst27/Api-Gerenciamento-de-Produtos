using ApiProdutos.Business;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly ContratoBusiness _business;

        public ContratoController(ContratoBusiness business)
        {
            _business = business;
        }

        [HttpGet("{id}")]
        public ActionResult<Contrato> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contrato>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<Contrato> Post([FromBody] Contrato contrato)
        {
            if (contrato is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(contrato));
        }

        [HttpPut]
        public ActionResult<Contrato> Put([FromBody] Contrato contrato)
        {
            if (contrato is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(contrato));
        }

        [HttpDelete("{id}")]
        public ActionResult<Contrato> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Contrato não encontrado");
            
            return Ok(_business.Delete(id));
        }

    }
}
