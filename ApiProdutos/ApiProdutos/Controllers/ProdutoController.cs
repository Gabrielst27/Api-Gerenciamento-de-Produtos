using ApiProdutos.Models;
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
        private readonly IUnitOfWork _uof;

        public ProdutoController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get([FromRoute] long id)
        {
            var produto = _uof.ProdutoRepository.Get(p => p.Id == id);
            return Ok(produto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAll()
        {
            return Ok(_uof.ProdutoRepository.GetAll());
        }

        [HttpPost]
        public ActionResult<Produto> Post([FromBody] Produto produto)
        {
            produto.Nome = PrimeiraMaiuscula.Corrigir(produto.Nome);
            produto.Descricao = PrimeiraMaiuscula.Corrigir(produto.Descricao);

            if (produto is null) return BadRequest("Dados inválidos");

            _uof.ProdutoRepository.Create(produto);
            _uof.Commit();
            return Ok(produto);
        }

        [HttpPut]
        public ActionResult<Produto> Put([FromBody] Produto produto)
        {
            produto.Nome = PrimeiraMaiuscula.Corrigir(produto.Nome);
            produto.Descricao = PrimeiraMaiuscula.Corrigir(produto.Descricao);

            if (produto is null) return BadRequest("Dados inválidos");

            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete([FromRoute] long id)
        {
            var produto = _uof.ProdutoRepository.Get(p => p.Id == id);
            _uof.ProdutoRepository.Delete(p => p.Id == id);
            _uof.Commit();
            return Ok();
        }

    }
}
