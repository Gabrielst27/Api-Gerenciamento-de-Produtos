using ApiProdutos.Business;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ProdutoBusiness _business;

        public ProdutoController(ProdutoBusiness business)
        {
            _business = business;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }
        /*
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<Produto> Post([FromBody] Produto produto)
        {
            if (produto is null) return BadRequest("Dados inválidos");

            var prod = _business.Create(produto);

            return Ok(prod);
        }

        [HttpPut]
        public ActionResult<Produto> Put([FromBody] Produto produto)
        {
            if (produto is null) return BadRequest("Dados inválidos");
            
            var prod = _business.Update(produto);

            return Ok(prod);
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete([FromRoute] long id)
        {
            var produto = _business.Get(id);
            if (produto is null) return BadRequest("Produto não encontrado");

            var prod = _business.Delete(id);
            
            return Ok(prod);
        }
        */
    }
}
