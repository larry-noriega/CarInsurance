using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CarInsurance.Core.Models;

public class Document
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}