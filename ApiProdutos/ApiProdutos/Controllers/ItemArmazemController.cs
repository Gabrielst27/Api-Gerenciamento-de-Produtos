using ApiProdutos.Business;
using ApiProdutos.Models;
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
        public ActionResult<ItemArmazem> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemArmazem>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<ItemArmazem> Post([FromBody] ItemArmazem itemArmazem)
        {
            if (itemArmazem is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(itemArmazem));
        }

        [HttpPut]
        public ActionResult<ItemArmazem> Put([FromBody] ItemArmazem itemArmazem)
        {
            if (itemArmazem is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(itemArmazem));
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemArmazem> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Item do armazem não encontrado");

            return Ok(_business.Delete(id));
        }

    }
}
