using EventDrive.Shop.Shared.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventDriven.Shop.Stock.Application.EventHandlers
{
    public class AtualizarEstoqueEventHandler : Commander.Core.EventHandler<AtualizarEstoqueEvent>
    {
        public async override Task HandleEvent(AtualizarEstoqueEvent @event)
        {
            Console.WriteLine("Chegou evento " + @event.ProdutoId);
        }
    }
}
