namespace YourNamespace.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string LandLordId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string TenantId { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime From { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime To { get; set; }
    }
}
