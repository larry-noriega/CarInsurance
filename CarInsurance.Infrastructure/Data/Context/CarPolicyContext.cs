using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.CarPolicy;
using CarInsurance.Core.Models.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarInsurance.Infrastructure.Data.Context;


public class CarPolicyContext : ICarPolicyContext
{
    private readonly IMongoDatabase _carInsuranceCollection;

    public CarPolicyContext(IOptions<CarInsuranceDBSettings> options)
    {
        MongoClient mongoClient = new(options.Value.ConnectionString);

        _carInsuranceCollection = mongoClient.GetDatabase(options.Value.DatabaseName);
    }

    public IMongoCollection<Policy> CarInsurance => _carInsuranceCollection.GetCollection<Policy>("CarPolicies");
   
}

