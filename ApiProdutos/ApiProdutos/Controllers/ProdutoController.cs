using ApiProdutos.Business;
using ApiProdutos.DTOs;
using ApiProdutos.Models;
using ApiProdutos.Pagination;
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
        public ActionResult<ProdutoDTO> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<ProdutoDTO>> GetPag([FromQuery] GenericParameters genericParameters)
        {
            return Ok(_business.GetPag(genericParameters));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDTO>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<ProdutoDTO> Post([FromBody] ProdutoDTO produto)
        {
            if (produto is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(produto));
        }

        [HttpPut]
        public ActionResult<ProdutoDTO> Put([FromBody] ProdutoDTO produto)
        {
            if (produto is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(produto));
        }

        [HttpDelete("{id}")]
        public ActionResult<ProdutoDTO> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Produto não encontrado");
            
            return Ok(_business.Delete(id));
        }
    }
}
