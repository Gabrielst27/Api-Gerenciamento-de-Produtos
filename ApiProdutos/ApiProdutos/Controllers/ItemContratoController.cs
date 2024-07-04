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
        private readonly IRepository<ItemContrato> _repository;

        public ItemContratoController(IRepository<ItemContrato> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemContrato> Get([FromRoute] long id)
        {
            var itemContrato = _repository.Get(p => p.Id == id);
            return Ok(itemContrato);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemContrato>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult<ItemContrato> Post([FromBody] ItemContrato itemContrato)
        {
            if (itemContrato is null) return BadRequest("Dados inválidos");

            _repository.Create(itemContrato);
            return Ok(itemContrato);
        }

        [HttpPut]
        public ActionResult<ItemContrato> Put([FromBody] ItemContrato itemContrato)
        {
            if (itemContrato is null) return BadRequest("Dados inválidos");

            _repository.Update(itemContrato);
            return Ok(itemContrato);
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemContrato> Delete([FromRoute] long id)
        {
            var itemContrato = _repository.Get(p => p.Id == id);
            _repository.Delete(p => p.Id == id);
            return Ok(itemContrato);
        }

    }
}
