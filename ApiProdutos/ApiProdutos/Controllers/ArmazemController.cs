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
    public class ArmazemController : ControllerBase
    {
        private readonly ArmazemBusiness _business;

        public ArmazemController(ArmazemBusiness business)
        {
            _business = business;
        }

        [HttpGet("{id}")]
        public ActionResult<ArmazemDTO> Get([FromRoute] long id)
        {
            return Ok(_business.Get(id));
        }

        [HttpGet("pagination")]
        public ActionResult<IEnumerable<ArmazemDTO>> GetPag([FromQuery] GenericParameters genericParameters)
        {
            return Ok(_business.GetPag(genericParameters));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArmazemDTO>> GetAll()
        {
            return Ok(_business.GetAll());
        }

        [HttpPost]
        public ActionResult<ArmazemDTO> Post([FromBody] ArmazemDTO armazem)
        {
            if (armazem is null) return BadRequest("Dados inválidos");

            return Ok(_business.Create(armazem));
        }

        [HttpPut]
        public ActionResult<ArmazemDTO> Put([FromBody] ArmazemDTO armazem)
        {
            if (armazem is null) return BadRequest("Dados inválidos");

            return Ok(_business.Update(armazem));
        }

        [HttpDelete("{id}")]
        public ActionResult<ArmazemDTO> Delete([FromRoute] long id)
        {
            if (_business.Get(id) is null) return BadRequest("Armazem não encontrado");

            return Ok(_business.Delete(id));
        }

    }
}
