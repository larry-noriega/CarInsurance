using CarInsurance.Core.Models.CarPolicy;
using CarInsurance.Core.Models.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Diagnostics;

namespace CarInsurance.Core.Services;

public class CarPoliciesService
{
    private readonly IMongoCollection<CarPolicyModel> _carPolicyCollection;
    
    public CarPoliciesService(IOptions<CarInsuranceDBSettings> carPolicyDatabaseSettings)
    {
        var stringConnection = carPolicyDatabaseSettings.Value.ConnectionString;

        Debug.WriteLine("---->>>" + stringConnection);

        MongoClient mongoClient = new(stringConnection);

        IMongoDatabase? mongoDatabase = mongoClient.GetDatabase( carPolicyDatabaseSettings.Value.DatabaseName );

        _carPolicyCollection = mongoDatabase.GetCollection<CarPolicyModel>( carPolicyDatabaseSettings.Value.CarPolicyCollectionName );
    }

    public async Task<List<CarPolicyModel>> GetAsync() =>
        await _carPolicyCollection.Find(_ => true).ToListAsync();

    public async Task<CarPolicyModel?> GetAsync(string id) =>
        await _carPolicyCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(CarPolicyModel carPolicy) =>
        await _carPolicyCollection.InsertOneAsync(carPolicy);

    public async Task UpdateAsync(string id, CarPolicyModel updatedCarPolicy) =>
        await _carPolicyCollection.ReplaceOneAsync(x => x.Id == id, updatedCarPolicy);

    public async Task RemoveAsync(string id) =>
        await _carPolicyCollection.DeleteOneAsync(x => x.Id == id);
}
