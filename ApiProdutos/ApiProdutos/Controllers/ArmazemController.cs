using ApiProdutos.Models;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiCategorias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmazemController : ControllerBase
    {
        private readonly IRepository<Armazem> _repository;

        public ArmazemController(IRepository<Armazem> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Armazem> Get([FromRoute] long id)
        {
            var armazem = _repository.Get(p => p.Id == id);
            return Ok(armazem);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Armazem>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult<Armazem> Post([FromBody] Armazem armazem)
        {
            if (armazem is null) return BadRequest("Dados inválidos");

            _repository.Create(armazem);
            return Ok(armazem);
        }

        [HttpPut]
        public ActionResult<Armazem> Put([FromBody] Armazem armazem)
        {
            if (armazem is null) return BadRequest("Dados inválidos");

            _repository.Update(armazem);
            return Ok(armazem);
        }

        [HttpDelete("{id}")]
        public ActionResult<Armazem> Delete([FromRoute] long id)
        {
            var armazem = _repository.Get(p => p.Id == id);
            _repository.Delete(p => p.Id == id);
            return Ok(armazem);
        }

    }
}
