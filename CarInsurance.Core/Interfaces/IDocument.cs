using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CarInsurance.Core.Interfaces;

public class IDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

}