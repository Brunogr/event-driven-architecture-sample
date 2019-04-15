using Commander.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventDriven.Shop.Cart.Domain.Commands
{
    public class AdicionarProdutoAoCarrinhoCommand : Command
    {
        public Guid IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public string NomeComprador { get; set; }
        public override bool Validate()
        {
            return true;
        }
    }
}
