namespace YourNamespace.Model
{
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Document
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string TenantId { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string LandLordId { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string PropertyId { get; set; }

    [BsonRepresentation(BsonType.String)]
    public string Doc { get; set; }

    [BsonRepresentation(BsonType.Boolean)]
    public bool isVerified { get; set; }
}
}
