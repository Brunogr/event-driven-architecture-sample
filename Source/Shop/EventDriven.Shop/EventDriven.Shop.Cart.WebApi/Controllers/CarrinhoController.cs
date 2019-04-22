using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Abstractions;
using Commander.MessageBus.Abstractions;
using EventDrive.Shop.Cart.Infra.Database.Interfaces;
using EventDriven.Shop.Cart.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EventDriven.Shop.Cart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly IMessageBus messageBus;
        private readonly ICarrinhoRepository carrinhoRepository;
        public CarrinhoController(IMessageBus messageBus, ICarrinhoRepository carrinhoRepository)
        {
            this.messageBus = messageBus;
            this.carrinhoRepository = carrinhoRepository;
        }
        
        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AdicionarProdutoAoCarrinhoCommand command)
        {
            await messageBus.PublishAsync(command);

            return Ok(command);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var carrinhos = await carrinhoRepository.GetAllAsync();

            return Ok(carrinhos);
        }

    }
}
