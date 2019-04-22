using EventDriven.Shop.Stock.Domain.Models;
using EventDriven.Shop.Stock.Infra.Database.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EventDriven.Shop.Stock.Infra.Database
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Produto> collection;

        public ProdutoRepository()
        {
            client = new MongoClient("mongodb+srv://admin:admin@cluster0-f7uk1.mongodb.net/test?retryWrites=true");
            database = client.GetDatabase("ShopStock");
            collection = database.GetCollection<Produto>("Produto");
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return (await collection.FindAsync(new BsonDocument())).ToList();
        }

        public Task<Produto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produto>> GetByFilterAsync(Expression<Func<Produto, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Produto> InsertAsync(Produto produto)
        {
            await collection.InsertOneAsync(produto);

            return produto;
        }

        public Task<Produto> UpdateAsync(Produto pedido)
        {
            throw new NotImplementedException();
        }
    }
}
