
using CarInsurance.API.Models;
using CarInsurance.API.Models.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Diagnostics;

namespace CarInsurance.API;

public class CarPoliciesService
{
    private readonly IMongoCollection<CarPolicy> _carPolicyCollection;
    
    public CarPoliciesService(IOptions<CarPoliciesDatabaseSettings> carPolicyDatabaseSettings)
    {
        var stringConnection = carPolicyDatabaseSettings.Value.ConnectionString;

        Debug.WriteLine("---->>>" + stringConnection);

        MongoClient mongoClient = new(stringConnection);

        IMongoDatabase? mongoDatabase = mongoClient.GetDatabase( carPolicyDatabaseSettings.Value.DatabaseName );

        _carPolicyCollection = mongoDatabase.GetCollection<CarPolicy>( carPolicyDatabaseSettings.Value.CarPolicyCollectionName );
    }

    public async Task<List<CarPolicy>> GetAsync() =>
        await _carPolicyCollection.Find(_ => true).ToListAsync();

    public async Task<CarPolicy?> GetAsync(string id) =>
        await _carPolicyCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(CarPolicy carPolicy) =>
        await _carPolicyCollection.InsertOneAsync(carPolicy);

    public async Task UpdateAsync(string id, CarPolicy updatedCarPolicy) =>
        await _carPolicyCollection.ReplaceOneAsync(x => x.Id == id, updatedCarPolicy);

    public async Task RemoveAsync(string id) =>
        await _carPolicyCollection.DeleteOneAsync(x => x.Id == id);
}
