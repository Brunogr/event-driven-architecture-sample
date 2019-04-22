using EventDriven.Shop.Cart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventDrive.Shop.Cart.Infra.Database.Interfaces
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho> InsertAsync(Carrinho estoque);
        Task<Carrinho> UpdateAsync(Carrinho estoque);
        Task<List<Carrinho>> GetAllAsync();
        Task<List<Carrinho>> GetByFilterAsync(Expression<Func<Carrinho, bool>> filter);
    }
}
