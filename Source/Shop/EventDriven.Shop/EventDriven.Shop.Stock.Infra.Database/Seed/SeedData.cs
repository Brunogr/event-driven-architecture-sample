using EventDriven.Shop.Stock.Domain.Models;
using EventDriven.Shop.Stock.Infra.Database.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDriven.Shop.Stock.Infra.Database.Seed
{
    public static class SeedData
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            var produtoRepository = serviceProvider.GetRequiredService<IProdutoRepository>();
            var estoqueRepository = serviceProvider.GetRequiredService<IEstoqueRepository>();

            if ((await produtoRepository.GetAllAsync()).Any() && (await estoqueRepository.GetAllAsync()).Any())
                return;

            var produtos = new List<Produto>()
            {
                new Produto("TV 4K LG", 2299M),
                new Produto("Microondas Brastemp", 599M),
                new Produto("Notebook Dell", 4000M)
            };

            foreach (var produto in produtos)
            {
                await produtoRepository.InsertAsync(produto);
            }

            var estoques = new List<Estoque>()
            {
                new Estoque(produtos[0], 10),
                new Estoque(produtos[1], 35),
                new Estoque(produtos[2], 5)
            };

            foreach (var estoque in estoques)
            {
                await estoqueRepository.InsertAsync(estoque);
            }
        }
    }
}
