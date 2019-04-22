using EventDriven.Shop.Stock.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventDriven.Shop.Stock.Infra.Database.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetAsync(Guid id);
        Task<Produto> InsertAsync(Produto produto);
        Task<List<Produto>> GetAllAsync();
        Task<List<Produto>> GetByFilterAsync(Expression<Func<Produto, bool>> filter);
        Task<Produto> UpdateAsync(Produto pedido);
        Task<bool> DeleteAsync(Guid id);
    }
}
