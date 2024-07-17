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
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaBusiness _business;

        public CategoriaController(CategoriaBusiness business)
        {
            _business = business;
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria categoria)
        {
            if (categoria is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(categoria));
        }

        [HttpPut]
        public ActionResult<Categoria> Put([FromBody] Categoria categoria)
        {
            if (categoria is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(categoria));
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Categoria não encontrada");

            return Ok(_business.Delete(id));
        }

    }
}
