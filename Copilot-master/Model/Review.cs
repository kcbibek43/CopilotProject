using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace YourNamespace.Model
{
    public class Reviews
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string PropertyId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public List<string> Review { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public List<int> Rating { get; set; }

        [BsonRepresentation(BsonType.String)]
        public List<string> userName { get; set; }
    }
}
