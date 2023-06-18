using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarInsurance.API.Models;

public class CarPolicy
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public decimal Number { get; set; }

    public DateTime CreationDate { get; set;}

    public DateTime ExpirationDate { get; set;}

    public decimal Amount { get; set; }

    public string[] Coverage { get; set; } = null!;

    public string Name { get; set; } = null!;

    public Customer Customer { get; set; } = null!;

    public Car Car { get; set; } = null!;
}
