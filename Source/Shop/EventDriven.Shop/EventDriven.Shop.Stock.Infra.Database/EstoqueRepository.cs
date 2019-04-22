using EventDriven.Shop.Stock.Domain.Models;
using EventDriven.Shop.Stock.Infra.Database.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EventDriven.Shop.Stock.Infra.Database
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Estoque> collection;

        public EstoqueRepository()
        {
            client = new MongoClient("mongodb+srv://admin:admin@cluster0-f7uk1.mongodb.net/test?retryWrites=true");
            database = client.GetDatabase("ShopStock");
            collection = database.GetCollection<Estoque>("Estoque");
        }

        public async Task<List<Estoque>> GetAllAsync()
        {
            return (await collection.FindAsync(new BsonDocument())).ToList();
        }

        public async Task<List<Estoque>> GetByFilterAsync(Expression<Func<Estoque, bool>> filter)
        {
            FilterDefinition<Estoque> filters = Builders<Estoque>.Filter.Where(filter);
            return (await collection.FindAsync(filters)).ToList();
        }

        public async Task<Estoque> InsertAsync(Estoque estoque)
        {
            await collection.InsertOneAsync(estoque);

            return estoque;
        }

        public async Task<Estoque> UpdateAsync(Estoque estoque)
        {
            FilterDefinition<Estoque> filters = Builders<Estoque>.Filter.Where(f => f.Id == estoque.Id);
            UpdateDefinition<Estoque> update = Builders<Estoque>.Update
                .Set(u => u.QuantidadeDisponivel, estoque.QuantidadeDisponivel);

            await collection.UpdateOneAsync(filters, update);

            return estoque;
        }
    }
}
