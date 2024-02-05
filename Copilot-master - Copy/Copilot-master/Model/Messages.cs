using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace YourNamespace.Model
{
    public class messages
    {
        public DateTime date { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
    }

    public class Messages
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string TenantId { get; set; }
        public string LandLordId { get; set; }
        public List<messages> messages { get; set; }
    }
}
