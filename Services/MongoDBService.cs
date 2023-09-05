﻿using test.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace test.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<GList> _listCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _listCollection = database.GetCollection<GList>(mongoDBSettings.Value.Collection);
        }

        public async Task CreateAsync(GList glist) {
            await _listCollection.InsertOneAsync(glist);
            return;
        }

        public async Task<List<GList>> GetAsync()
        {
            return await _listCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddToListAsync(string id, Item items)
        {
            FilterDefinition<GList> filter = Builders<GList>.Filter.Eq("Id", id);
            UpdateDefinition<GList> update = Builders<GList>.Update.AddToSet<Item>("items", items);
            await _listCollection.UpdateOneAsync(filter, update);

            return;
        }

        public async Task EditItem(string id, string itemName,Item editedItem)
        {


            var filter = Builders<GList>.Filter.And(
            Builders<GList>.Filter.Eq("Id", id),
            Builders<GList>.Filter.Eq("items.Name", itemName));

            var update = Builders<GList>.Update.Set("items.$.Name", editedItem.Name)
                                             .Set("items.$.Quantity", editedItem.Quantity)
                                             .Set("items.$.Check", editedItem.Check);

            await _listCollection.UpdateOneAsync(filter, update);

            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<GList> filter = Builders<GList>.Filter.Eq("Id", id);
            await _listCollection.DeleteOneAsync(filter);

            return;
        }
    }
}