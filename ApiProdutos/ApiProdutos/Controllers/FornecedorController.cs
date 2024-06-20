using ApiProdutos.Models;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiCategorias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IRepository<Fornecedor> _repository;

        public FornecedorController(IRepository<Fornecedor> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Fornecedor> Get([FromRoute] long id)
        {
            var fornecedor = _repository.Get(p => p.Id == id);
            return Ok(fornecedor);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult<Fornecedor> Post([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor is null) return BadRequest("Dados inválidos");

            _repository.Create(fornecedor);
            return Ok(fornecedor);
        }

        [HttpPut]
        public ActionResult<Fornecedor> Put([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor is null) return BadRequest("Dados inválidos");

            _repository.Update(fornecedor);
            return Ok(fornecedor);
        }

        [HttpDelete("{id}")]
        public ActionResult<Fornecedor> Delete([FromRoute] long id)
        {
            var fornecedor = _repository.Get(p => p.Id == id);
            _repository.Delete(p => p.Id == id);
            return Ok(fornecedor);
        }

    }
}
