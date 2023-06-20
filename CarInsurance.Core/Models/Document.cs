using CarInsurance.Core.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CarInsurance.Core.Models;

public class Document : IDocument
{
    private Guid number;
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Number
    {
        get
        {
            number = Guid.NewGuid();

            return number;
        }
        set => number = value;
    }
}