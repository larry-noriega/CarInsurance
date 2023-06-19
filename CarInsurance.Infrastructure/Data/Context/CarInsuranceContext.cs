using CarInsurance.Core.Models.CarInsurance;
using CarInsurance.Core.Models.Settings;
using CarInsurance.Core.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarInsurance.Infrastructure.Data.Context;

public class CarInsuranceContext : ICarInsuranceContext
{
    private readonly IMongoDatabase _carInsuranceCollection;

    public CarInsuranceContext(IOptions<CarInsuranceDBSettings> options)
    {
        MongoClient mongoClient = new(options.Value.ConnectionString);

        _carInsuranceCollection = mongoClient.GetDatabase(options.Value.DatabaseName);
    }

    public IMongoCollection<Insurance> CarInsurance => _carInsuranceCollection.GetCollection<Insurance>("CarInsurance");
}