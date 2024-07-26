using ApiProdutos.Business;
using ApiProdutos.DTOs;
using ApiProdutos.Models;
using ApiProdutos.Pagination;
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
        public ActionResult<ItemContratoDTO> Get([FromRoute] long id)
        {
           return Ok(_business.Get(id));
        }

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<ItemContratoDTO>> GetPag([FromQuery] GenericParameters genericParameters)
        {
            return Ok(_business.GetPag(genericParameters));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemContratoDTO>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<ItemContratoDTO> Post([FromBody] ItemContratoDTO itemContrato)
        {
            if (itemContrato is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(itemContrato));
        }

        [HttpPut]
        public ActionResult<ItemContratoDTO> Put([FromBody] ItemContratoDTO itemContrato)
        {
            if (itemContrato is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(itemContrato));
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemContratoDTO> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Item do contrato não encontrado");

            return Ok(_business.Delete(id));
        }

    }
}
