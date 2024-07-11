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
        private readonly IUnitOfWork _uof;

        public ContratoController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public ActionResult<Contrato> Get([FromRoute] long id)
        {
            var contrato = _uof.ContratoRepository.Get(p => p.Id == id);
            return Ok(contrato);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contrato>> GetAll()
        {
            return Ok(_uof.ContratoRepository.GetAll());
        }

        [HttpPost]
        public ActionResult<Contrato> Post([FromBody] Contrato contrato)
        {
            contrato.Representante = PrimeiraMaiuscula.Corrigir(contrato.Representante);

            if (contrato is null) return BadRequest("Dados inválidos");

            _uof.ContratoRepository.Create(contrato);
            _uof.Commit();
            return Ok(contrato);
        }

        [HttpPut]
        public ActionResult<Contrato> Put([FromBody] Contrato contrato)
        {
            contrato.Representante = PrimeiraMaiuscula.Corrigir(contrato.Representante);

            if (contrato is null) return BadRequest("Dados inválidos");

            _uof.ContratoRepository.Update(contrato);
            _uof.Commit();
            return Ok(contrato);
        }

        [HttpDelete("{id}")]
        public ActionResult<Contrato> Delete([FromRoute] long id)
        {
            var contrato = _uof.ContratoRepository.Get(p => p.Id == id);
            _uof.ContratoRepository.Delete(p => p.Id == id);
            _uof.Commit();
            return Ok(contrato);
        }

    }
}
