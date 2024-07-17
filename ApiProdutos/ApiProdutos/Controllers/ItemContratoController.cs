using ApiProdutos.Business;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemContratoController : ControllerBase
    {
        private readonly ItemContratoBusiness _business;

        public ItemContratoController(ItemContratoBusiness business)
        {
            _business = business;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemContrato> Get([FromRoute] long id)
        {
           return Ok(_business.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemContrato>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<ItemContrato> Post([FromBody] ItemContrato itemContrato)
        {
            if (itemContrato is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(itemContrato));
        }

        [HttpPut]
        public ActionResult<ItemContrato> Put([FromBody] ItemContrato itemContrato)
        {
            if (itemContrato is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(itemContrato));
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemContrato> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Item do contrato não encontrado");

            return Ok(_business.Delete(id));
        }

    }
}
