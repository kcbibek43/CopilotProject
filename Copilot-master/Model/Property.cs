namespace YourNamespace.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Collections.Generic;

    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Location { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string LandLordId { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Rent { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Type { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int NumOfRooms { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsAvailable { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime AvailableFrom { get; set; }

        [BsonRepresentation(BsonType.String)]
        public List<string> Ameneties { get; set; }

        [BsonRepresentation(BsonType.String)]
        public List<string> Images { get; set; }
    }
}
