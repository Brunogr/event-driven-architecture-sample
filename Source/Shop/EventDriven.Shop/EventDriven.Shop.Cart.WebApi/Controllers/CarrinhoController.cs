using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Abstractions;
using Commander.MessageBus.Abstractions;
using EventDriven.Shop.Cart.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EventDriven.Shop.Cart.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private readonly IMessageBus messageBus;
        public CarrinhoController(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }
        
        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AdicionarProdutoAoCarrinhoCommand command)
        {
            await messageBus.PublishAsync(command);

            return Ok(command);
        }
        
    }
}
