using System;
using System.Collections.Generic;
using System.Text;

namespace EventDriven.Shop.Stock.Domain.Models
{
    public class Estoque
    {
        protected Estoque() { }
        public Estoque(Produto produto, int quantidadeDisponivel)
        {
            Id = Guid.NewGuid();
            Produto = produto;
            QuantidadeDisponivel = quantidadeDisponivel;
        }

        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeDisponivel { get; set; }
    }
}
