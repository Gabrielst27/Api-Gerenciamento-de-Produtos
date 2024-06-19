using ApiProdutos.Models;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepository<Produto> _repository;

        public ProdutoController(IRepository<Produto> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get([FromRoute] long id)
        {
            var produto = _repository.Get(p => p.Id == id);
            return Ok(produto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult<Produto> Post([FromBody] Produto produto)
        {
            if (produto is null) return BadRequest("Dados inválidos");

            _repository.Create(produto);
            return Ok(produto);
        }

        [HttpPut]
        public ActionResult<Produto> Put([FromBody] Produto produto)
        {
            if (produto is null) return BadRequest("Dados inválidos");

            _repository.Update(produto);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete([FromRoute] long id)
        {
            var produto = _repository.Get(p => p.Id == id);
            _repository.Delete(p => p.Id == id);
            return Ok();
        }

    }
}
