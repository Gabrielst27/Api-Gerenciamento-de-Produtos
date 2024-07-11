using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public SubcategoriaController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public ActionResult<Subcategoria> Get([FromRoute] long id)
        {
            var subcategoria = _uof.SubcategoriaRepository.Get(p => p.Id == id);
            return Ok(subcategoria);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Subcategoria>> GetAll()
        {
            return Ok(_uof.SubcategoriaRepository.GetAll());
        }

        [HttpPost]
        public ActionResult<Subcategoria> Post([FromBody] Subcategoria subcategoria)
        {
            subcategoria.Nome = PrimeiraMaiuscula.Corrigir(subcategoria.Nome);

            if (subcategoria is null) return BadRequest("Dados inválidos");

            _uof.SubcategoriaRepository.Create(subcategoria);
            _uof.Commit();
            return Ok(subcategoria);
        }

        [HttpPut]
        public ActionResult<Subcategoria> Put([FromBody] Subcategoria subcategoria)
        {
            subcategoria.Nome = PrimeiraMaiuscula.Corrigir(subcategoria.Nome);

            if (subcategoria is null) return BadRequest("Dados inválidos");

            _uof.SubcategoriaRepository.Update(subcategoria);
            _uof.Commit();
            return Ok(subcategoria);
        }

        [HttpDelete("{id}")]
        public ActionResult<Subcategoria> Delete([FromRoute] long id)
        {
            var subcategoria = _uof.SubcategoriaRepository.Get(p => p.Id == id);
            _uof.SubcategoriaRepository.Delete(p => p.Id == id);
            _uof.Commit();
            return Ok(subcategoria);
        }

    }
}
