using EventDriven.Shop.Stock.Domain.Models;
using EventDriven.Shop.Stock.Infra.Database.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventDriven.Shop.Stock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepository estoqueRepository;
        public EstoqueController(IEstoqueRepository produtoRepository)
        {
            this.estoqueRepository = produtoRepository;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estoque>>> Get()
        {
            return Ok(await estoqueRepository.GetAllAsync());
        }
    }
}
