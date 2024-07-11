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
        private readonly IUnitOfWork _uof;

        public ItemContratoController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemContrato> Get([FromRoute] long id)
        {
            var itemContrato = _uof.ItemContratoRepository.Get(p => p.Id == id);
            return Ok(itemContrato);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemContrato>> GetAll()
        {
            return Ok(_uof.ItemContratoRepository.GetAll());
        }

        [HttpPost]
        public ActionResult<ItemContrato> Post([FromBody] ItemContrato itemContrato)
        {
            if (itemContrato is null) return BadRequest("Dados inválidos");

            _uof.ItemContratoRepository.Create(itemContrato);
            _uof.Commit();
            return Ok(itemContrato);
        }

        [HttpPut]
        public ActionResult<ItemContrato> Put([FromBody] ItemContrato itemContrato)
        {
            if (itemContrato is null) return BadRequest("Dados inválidos");

            _uof.ItemContratoRepository.Update(itemContrato);
            _uof.Commit();
            return Ok(itemContrato);
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemContrato> Delete([FromRoute] long id)
        {
            var itemContrato = _uof.ItemContratoRepository.Get(p => p.Id == id);
            _uof.ItemContratoRepository.Delete(p => p.Id == id);
            _uof.Commit();
            return Ok(itemContrato);
        }

    }
}
