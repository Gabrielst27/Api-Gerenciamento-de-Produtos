using ApiProdutos.Models;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiItemFornecedors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemFornecedorController : ControllerBase
    {
        private readonly IRepository<ItemFornecedor> _repository;

        public ItemFornecedorController(IRepository<ItemFornecedor> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemFornecedor> Get([FromRoute] long id)
        {
            var itemfornecedor = _repository.Get(p => p.Id == id);
            return Ok(itemfornecedor);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemFornecedor>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult<ItemFornecedor> Post([FromBody] ItemFornecedor itemfornecedor)
        {
            if (itemfornecedor is null) return BadRequest("Dados inválidos");

            _repository.Create(itemfornecedor);
            return Ok(itemfornecedor);
        }

        [HttpPut]
        public ActionResult<ItemFornecedor> Put([FromBody] ItemFornecedor itemfornecedor)
        {
            if (itemfornecedor is null) return BadRequest("Dados inválidos");

            _repository.Update(itemfornecedor);
            return Ok(itemfornecedor);
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemFornecedor> Delete([FromRoute] long id)
        {
            var itemfornecedor = _repository.Get(p => p.Id == id);
            _repository.Delete(p => p.Id == id);
            return Ok(itemfornecedor);
        }

    }
}
