using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IRepository<Contrato> _repository;

        public ContratoController(IRepository<Contrato> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Contrato> Get([FromRoute] long id)
        {
            var contrato = _repository.Get(p => p.Id == id);
            return Ok(contrato);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contrato>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult<Contrato> Post([FromBody] Contrato contrato)
        {
            contrato.Representante = PrimeiraMaiuscula.Corrigir(contrato.Representante);

            if (contrato is null) return BadRequest("Dados inválidos");

            _repository.Create(contrato);
            return Ok(contrato);
        }

        [HttpPut]
        public ActionResult<Contrato> Put([FromBody] Contrato contrato)
        {
            contrato.Representante = PrimeiraMaiuscula.Corrigir(contrato.Representante);

            if (contrato is null) return BadRequest("Dados inválidos");

            _repository.Update(contrato);
            return Ok(contrato);
        }

        [HttpDelete("{id}")]
        public ActionResult<Contrato> Delete([FromRoute] long id)
        {
            var contrato = _repository.Get(p => p.Id == id);
            _repository.Delete(p => p.Id == id);
            return Ok(contrato);
        }

    }
}
