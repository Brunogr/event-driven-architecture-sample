using EventDriven.Shop.Shared.Events;
using EventDriven.Shop.Stock.Infra.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDriven.Shop.Stock.Application.EventHandlers
{
    public class AtualizarEstoqueEventHandler : Commander.Core.EventHandler<AtualizarEstoqueEvent>
    {
        private readonly IEstoqueRepository estoqueRepository;
        public AtualizarEstoqueEventHandler(IEstoqueRepository estoqueRepository)
        {
            this.estoqueRepository = estoqueRepository;
        }
        public async override Task HandleEvent(AtualizarEstoqueEvent @event)
        {
            var estoque = (await estoqueRepository.GetByFilterAsync(e => e.Produto.Id == @event.ProdutoId)).FirstOrDefault();

            if (estoque == null)
                return;

            estoque.QuantidadeDisponivel -= @event.Quantidade;

            await estoqueRepository.UpdateAsync(estoque);
        }
    }
}
