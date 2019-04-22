using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventDriven.Shop.Stock.Domain.Models;
using EventDriven.Shop.Stock.Infra.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventDriven.Shop.Stock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            return Ok(await produtoRepository.GetAllAsync());
        }
    }
}
