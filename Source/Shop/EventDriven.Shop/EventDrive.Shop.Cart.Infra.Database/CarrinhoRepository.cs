using EventDrive.Shop.Cart.Infra.Database.Interfaces;
using EventDriven.Shop.Cart.Domain.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EventDrive.Shop.Cart.Infra.Database
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Carrinho> collection;

        public CarrinhoRepository()
        {
            client = new MongoClient("mongodb+srv://admin:admin@cluster0-f7uk1.mongodb.net/test?retryWrites=true");
            database = client.GetDatabase("ShopCart");
            collection = database.GetCollection<Carrinho>("Carrinho");
        }

        public async Task<List<Carrinho>> GetAllAsync()
        {
            return (await collection.FindAsync(new BsonDocument())).ToList();
        }

        public async Task<List<Carrinho>> GetByFilterAsync(Expression<Func<Carrinho, bool>> filter)
        {
            FilterDefinition<Carrinho> filters = Builders<Carrinho>.Filter.Where(filter);
            return (await collection.FindAsync(filters)).ToList();
        }

        public async Task<Carrinho> InsertAsync(Carrinho carrinho)
        {
            await collection.InsertOneAsync(carrinho);

            return carrinho;
        }

        public async Task<Carrinho> UpdateAsync(Carrinho carrinho)
        {
            FilterDefinition<Carrinho> filters = Builders<Carrinho>.Filter.Where(f => f.Id == carrinho.Id);
            UpdateDefinition<Carrinho> update = Builders<Carrinho>.Update
                .Set(u => u.Produtos, carrinho.Produtos);

            await collection.UpdateOneAsync(filters, update);

            return carrinho;
        }
    }
}
