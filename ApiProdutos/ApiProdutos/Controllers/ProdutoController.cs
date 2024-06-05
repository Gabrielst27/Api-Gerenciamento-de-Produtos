using ApiProdutos.Models;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepository<Produto> _repository;

        public ProdutoController(IRepository<Produto> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(long id)
        {
            var produto = _repository.GetById(p => p.Id == id);
            return Ok(produto);
        }

    }
}
