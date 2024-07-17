using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Business;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private readonly SubcategoriaBusiness _business;

        public SubcategoriaController(SubcategoriaBusiness business)
        {
            _business = business;
        }

        [HttpGet("{id}")]
        public ActionResult<Subcategoria> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Subcategoria>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<Subcategoria> Post([FromBody] Subcategoria subcategoria)
        {
            if (subcategoria is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(subcategoria));
        }

        [HttpPut]
        public ActionResult<Subcategoria> Put([FromBody] Subcategoria subcategoria)
        {
            if (subcategoria is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(subcategoria));
        }

        [HttpDelete("{id}")]
        public ActionResult<Subcategoria> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Subcategoria não encontrada");
            
            return Ok(_business.Delete(id));
        }

    }
}
