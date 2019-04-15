using Commander.Abstractions;
using Commander.Core;
using EventDriven.Shop.Cart.Domain.Commands;
using EventDriven.Shop.Cart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventDriven.Shop.Cart.Application.CommandHandlers
{
    public class AdicionarProdutoAoCarrinhoCommandHandler : CommandHandler<AdicionarProdutoAoCarrinhoCommand>
    {
        public AdicionarProdutoAoCarrinhoCommandHandler(IHandler handler) : base(handler)
        {
        }

        public async override Task<CommandResult> HandleCommandAsync(AdicionarProdutoAoCarrinhoCommand command)
        {
            Console.WriteLine("PONG");

            var carrinho = new Carrinho(new Comprador() { Nome = command.NomeComprador }, new List<Produto>() { new Produto() { Nome = command.NomeProduto, Valor = command.ValorProduto, Id = command.IdProduto } });

            await AddEventsAsync(carrinho.DomainEvents.ToArray());

            return new CommandResult();
        }
    }
}
