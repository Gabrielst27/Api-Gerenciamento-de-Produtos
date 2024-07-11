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
        private readonly IUnitOfWork _uof;

        public ItemArmazemController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemArmazem> Get([FromRoute] long id)
        {
            var itemArmazem = _uof.ItemArmazemRepository.Get(p => p.Id == id);
            return Ok(itemArmazem);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemArmazem>> GetAll()
        {
            return Ok(_uof.ItemArmazemRepository.GetAll());
        }

        [HttpPost]
        public ActionResult<ItemArmazem> Post([FromBody] ItemArmazem itemArmazem)
        {
            if (itemArmazem is null) return BadRequest("Dados inválidos");

            _uof.ItemArmazemRepository.Create(itemArmazem);
            _uof.Commit();
            return Ok(itemArmazem);
        }

        [HttpPut]
        public ActionResult<ItemArmazem> Put([FromBody] ItemArmazem itemArmazem)
        {
            if (itemArmazem is null) return BadRequest("Dados inválidos");

            _uof.ItemArmazemRepository.Update(itemArmazem);
            _uof.Commit();
            return Ok(itemArmazem);
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemArmazem> Delete([FromRoute] long id)
        {
            var itemArmazem = _uof.ItemArmazemRepository.Get(p => p.Id == id);
            _uof.ItemArmazemRepository.Delete(p => p.Id == id);
            _uof.Commit();
            return Ok(itemArmazem);
        }

    }
}
