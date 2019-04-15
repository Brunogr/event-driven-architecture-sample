using EventDriven.Shop.Stock.Domain.Models;
using EventDriven.Shop.Stock.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDriven.Shop.Stock.Infra.Data.Seeds
{
    public static class DataSeed
    {
        public static void Initialize(StockContext context)
        {
            if (context.Estoques.Any())
                return;

            var produtos = new List<Produto>()
            {
                new Produto("Cerveja", 7.9m),
                new Produto("Refrigerante", 5.9m),
                new Produto("Biscoito", 2.5m),
                new Produto("Material de Limpeza", 10m)
            };

            context.Produtos.AddRange(produtos);

            context.SaveChanges();

            var estoques = new List<Estoque>()
            {
                new Estoque(produtos[0], 5),
                new Estoque(produtos[1], 10),
                new Estoque(produtos[2], 100),
                new Estoque(produtos[3], 15)
            };

            context.Estoques.AddRange(estoques);

            context.SaveChanges();
        }
    }
}
