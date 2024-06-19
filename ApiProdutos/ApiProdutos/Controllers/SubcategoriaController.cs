using ApiProdutos.Models;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiSubcategorias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private readonly IRepository<Subcategoria> _repository;

        public SubcategoriaController(IRepository<Subcategoria> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Subcategoria> Get([FromRoute] long id)
        {
            var subcategoria = _repository.Get(p => p.Id == id);
            return Ok(subcategoria);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Subcategoria>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult<Subcategoria> Post([FromBody] Subcategoria subcategoria)
        {
            if (subcategoria is null) return BadRequest("Dados inválidos");

            _repository.Create(subcategoria);
            return Ok(subcategoria);
        }

        [HttpPut]
        public ActionResult<Subcategoria> Put([FromBody] Subcategoria subcategoria)
        {
            if (subcategoria is null) return BadRequest("Dados inválidos");

            _repository.Update(subcategoria);
            return Ok(subcategoria);
        }

        [HttpDelete("{id}")]
        public ActionResult<Subcategoria> Delete([FromRoute] long id)
        {
            var subcategoria = _repository.Get(p => p.Id == id);
            _repository.Delete(p => p.Id == id);
            return Ok(subcategoria);
        }

    }
}
