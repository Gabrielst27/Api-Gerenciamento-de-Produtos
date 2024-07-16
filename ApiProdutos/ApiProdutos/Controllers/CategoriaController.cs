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
        private readonly IUnitOfWork _uof;

        public CategoriaController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> Get([FromRoute] long id)
        {
            var categoria = _uof.CategoriaRepository.Get(p => p.Id == id);
            return Ok(categoria);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetAll()
        {
            return Ok(_uof.CategoriaRepository.GetAll());
        }

        [HttpPost]
        public ActionResult<Categoria> Post([FromBody] Categoria categoria)
        {

            if (categoria is null) return BadRequest("Dados inválidos");

            _uof.CategoriaRepository.Create(categoria);
            _uof.Commit();
            return Ok(categoria);
        }

        [HttpPut]
        public ActionResult<Categoria> Put([FromBody] Categoria categoria)
        {

            if (categoria is null) return BadRequest("Dados inválidos");

            _uof.CategoriaRepository.Update(categoria);
            _uof.Commit();
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete([FromRoute] long id)
        {
            var categoria = _uof.CategoriaRepository.Get(p => p.Id == id);
            _uof.CategoriaRepository.Delete(p => p.Id == id);
            _uof.Commit();
            return Ok(categoria);
        }

    }
}
