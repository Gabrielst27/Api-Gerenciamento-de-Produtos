using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IRepository<Categoria> _repository;

        public CategoriaController(IRepository<Categoria> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> Get([FromRoute] long id)
        {
            var categoria = _repository.Get(p => p.Id == id);
            return Ok(categoria);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria categoria)
        {
            categoria.Nome = PrimeiraMaiuscula.Corrigir(categoria.Nome);

            if (categoria is null) return BadRequest("Dados inválidos");

            _repository.Create(categoria);
            return Ok(categoria);
        }

        [HttpPut]
        public ActionResult<Categoria> Put([FromBody] Categoria categoria)
        {
            categoria.Nome = PrimeiraMaiuscula.Corrigir(categoria.Nome);

            if (categoria is null) return BadRequest("Dados inválidos");

            _repository.Update(categoria);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete([FromRoute] long id)
        {
            var categoria = _repository.Get(p => p.Id == id);
            _repository.Delete(p => p.Id == id);
            return Ok(categoria);
        }

    }
}
