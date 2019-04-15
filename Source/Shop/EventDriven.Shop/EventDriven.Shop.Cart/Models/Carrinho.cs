using EventDrive.Shop.Shared.Base;
using EventDrive.Shop.Shared.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventDriven.Shop.Cart.Domain.Models
{
    public class Carrinho : AggregateRoot
    {
        protected Carrinho() { }
        public Carrinho(Comprador comprador, List<Produto> produtos)
        {
            Id = Guid.NewGuid();
            Comprador = comprador;
            Produtos = produtos;

            foreach (var produto in Produtos)
            {
                AddEvent(new AtualizarEstoqueEvent(produto.Id));
            }
        }

        public Guid Id { get; set; }
        public Comprador Comprador { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
