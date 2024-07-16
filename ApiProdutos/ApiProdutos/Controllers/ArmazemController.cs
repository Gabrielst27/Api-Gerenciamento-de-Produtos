using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArmazemController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public ArmazemController(IUnitOfWork unitOfWork)
        {
            _uof = unitOfWork;
        }

        [HttpGet("{id}")]
        public ActionResult<Armazem> Get([FromRoute] long id)
        {
            var armazem = _uof.ArmazemRepository.Get(p => p.Id == id);
            return Ok(armazem);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Armazem>> GetAll()
        {
            return Ok(_uof.ArmazemRepository.GetAll());
        }

        [HttpPost]
        public ActionResult<Armazem> Post([FromBody] Armazem armazem)
        {

            if (armazem is null) return BadRequest("Dados inválidos");

            _uof.ArmazemRepository.Create(armazem);
            _uof.Commit();
            return Ok(armazem);
        }

        [HttpPut]
        public ActionResult<Armazem> Put([FromBody] Armazem armazem)
        {

            if (armazem is null) return BadRequest("Dados inválidos");

            _uof.ArmazemRepository.Update(armazem);
            _uof.Commit();
            return Ok(armazem);
        }

        [HttpDelete("{id}")]
        public ActionResult<Armazem> Delete([FromRoute] long id)
        {
            var armazem = _uof.ArmazemRepository.Get(p => p.Id == id);
            _uof.ArmazemRepository.Delete(p => p.Id == id);
            _uof.Commit();
            return Ok(armazem);
        }

    }
}
