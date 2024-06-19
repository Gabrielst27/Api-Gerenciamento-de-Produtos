using ApiProdutos.Models;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiCategorias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemArmazemController : ControllerBase
    {
        private readonly IRepository<ItemArmazem> _repository;

        public ItemArmazemController(IRepository<ItemArmazem> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemArmazem> Get([FromRoute] long id)
        {
            var itemArmazem = _repository.Get(p => p.Id == id);
            return Ok(itemArmazem);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemArmazem>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult<ItemArmazem> Post([FromBody] ItemArmazem itemArmazem)
        {
            if (itemArmazem is null) return BadRequest("Dados inválidos");

            _repository.Create(itemArmazem);
            return Ok(itemArmazem);
        }

        [HttpPut]
        public ActionResult<ItemArmazem> Put([FromBody] ItemArmazem itemArmazem)
        {
            if (itemArmazem is null) return BadRequest("Dados inválidos");

            _repository.Update(itemArmazem);
            return Ok(itemArmazem);
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemArmazem> Delete([FromRoute] long id)
        {
            var itemArmazem = _repository.Get(p => p.Id == id);
            _repository.Delete(p => p.Id == id);
            return Ok(itemArmazem);
        }

    }
}
