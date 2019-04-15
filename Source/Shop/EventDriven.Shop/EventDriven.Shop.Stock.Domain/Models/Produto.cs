using System;
using System.Collections.Generic;
using System.Text;

namespace EventDriven.Shop.Stock.Domain.Models
{
    public class Produto
    {
        protected Produto() { }
        public Produto(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
