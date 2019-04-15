using System;
using System.Collections.Generic;
using System.Text;

namespace EventDriven.Shop.Cart.Domain.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
