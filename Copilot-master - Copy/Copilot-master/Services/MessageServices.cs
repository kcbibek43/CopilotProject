using MongoDB.Driver;
using YourNamespace.Model;
using YourNamespace.Models;

namespace YourNamespace.Services {
    public class MessagesService
    {
    private readonly IMongoCollection<Messages> _messages;

    public MessagesService(MongoDBSettings settings)
    {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _messages = database.GetCollection<Messages>("Messages");
    }

    public List<Messages> Get() =>
        _messages.Find(messages => true).ToList();

    public Messages Get(string id) =>
        _messages.Find<Messages>(messages => messages.Id == id).FirstOrDefault();

    public Messages Create(Messages messages)
    {
        _messages.InsertOne(messages);
        return messages;
    }

    public List<Messages> GetByTenantId(string tenantId) =>
        _messages.Find<Messages>(message => message.TenantId == tenantId).ToList();

    public List<Messages> GetByLandlordId(string landlordId) =>
        _messages.Find<Messages>(message => message.LandLordId == landlordId).ToList();

    public void Update(string id, Messages messagesIn) =>
        _messages.ReplaceOne(messages => messages.Id == id, messagesIn);

    public void Remove(Messages messagesIn) =>
        _messages.DeleteOne(messages => messages.Id == messagesIn.Id);

    public void Remove(string id) => 
        _messages.DeleteOne(messages => messages.Id == id);
    }

}