﻿using Chattland.Api.DataAccess.Entities;
using Chattland.DataTransferContract.ChatContracts;
using MongoDB.Driver;

namespace Chattland.Api.DataAccess;

public class ChatMessageRepository : IChatMessageRepository
{
    private readonly IMongoDatabase _database;
    private string _collectionName;
    public ChatMessageRepository()
    {
        IMongoClient client = new MongoClient("mongodb://localhost:27017");
        _database = client.GetDatabase("Chattland");
        _collectionName = "Lobby";
    }

    public async Task<ChatMessage> GetByIdAsync(string id)
    {
        var collection = _database.GetCollection<ChatMessage>(_collectionName);
        var messages = await collection.FindAsync(id);
        var message = messages.FirstOrDefault();

        return message;
    }

    public async Task<IEnumerable<ChatMessage>> GetManyAsync(int start, int count)
    {
        var collection = _database.GetCollection<ChatMessage>(_collectionName);
        var messages = await collection.Find(_=> true).Skip(start).Limit(count).ToListAsync();
        return messages;
    }

    public async Task AddOneAsync(ChatMessage item)
    {
        var collection = 
            _database.GetCollection<ChatMessage>(
                _collectionName, 
                new MongoCollectionSettings()
                {
                    AssignIdOnInsert = true
                }
            );
        await collection.InsertOneAsync(item);
    }

    public void SetCollectionName(string name)
    {
        _collectionName = name;
    }
}