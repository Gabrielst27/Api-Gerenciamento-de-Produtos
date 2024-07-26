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
    public class ItemArmazemController : ControllerBase
    {
        private readonly ItemArmazemBusiness _business;

        public ItemArmazemController(ItemArmazemBusiness business)
        {
            _business = business;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemArmazemDTO> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<ItemArmazemDTO>> GetPag([FromQuery] GenericParameters genericParameters)
        {
            return Ok(_business.GetPag(genericParameters));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemArmazemDTO>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<ItemArmazemDTO> Post([FromBody] ItemArmazemDTO itemArmazem)
        {
            if (itemArmazem is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(itemArmazem));
        }

        [HttpPut]
        public ActionResult<ItemArmazemDTO> Put([FromBody] ItemArmazemDTO itemArmazem)
        {
            if (itemArmazem is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(itemArmazem));
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemArmazemDTO> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Item do armazem não encontrado");

            return Ok(_business.Delete(id));
        }

    }
}
