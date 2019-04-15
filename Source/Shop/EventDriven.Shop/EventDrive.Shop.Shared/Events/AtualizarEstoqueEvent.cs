using Commander.Abstractions;
using Commander.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventDrive.Shop.Shared.Events
{
    public class AtualizarEstoqueEvent : Event
    {
        public AtualizarEstoqueEvent(Guid produtoId)
        {
            ProdutoId = produtoId;
            Quantidade = 1;
        }

        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
