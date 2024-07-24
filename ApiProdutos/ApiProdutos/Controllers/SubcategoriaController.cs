using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Business;
using Microsoft.AspNetCore.Mvc;
using ApiProdutos.DTOs;

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
        public ActionResult<SubcategoriaDTO> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubcategoriaDTO>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<SubcategoriaDTO> Post([FromBody] SubcategoriaDTO subcategoria)
        {
            if (subcategoria is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(subcategoria));
        }

        [HttpPut]
        public ActionResult<SubcategoriaDTO> Put([FromBody] SubcategoriaDTO subcategoria)
        {
            if (subcategoria is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(subcategoria));
        }

        [HttpDelete("{id}")]
        public ActionResult<SubcategoriaDTO> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Subcategoria não encontrada");
            
            return Ok(_business.Delete(id));
        }

    }
}
