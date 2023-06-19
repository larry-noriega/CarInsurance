using CarInsurance.Core.Models.CarPolicy;
using CarInsurance.Core.Models.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarInsurance.Core.Services;

public class CarInsuranceService
{
    private readonly IMongoCollection<Insurance> _carInsuranceCollection;
    
    public CarInsuranceService(IOptions<CarInsuranceDBSettings> carInsuranceDBSettings)
    {
        MongoClient mongoClient = new(carInsuranceDBSettings.Value.ConnectionString);

        IMongoDatabase? mongoDatabase = mongoClient.GetDatabase( carInsuranceDBSettings.Value.DatabaseName );

        _carInsuranceCollection = mongoDatabase.GetCollection<Insurance>( carInsuranceDBSettings.Value.CarInsuranceCollectionName );
    }

    public async Task<List<Insurance>> GetAsync() =>
        await _carInsuranceCollection.Find(_ => true).ToListAsync();

    public async Task<Insurance?> GetAsync(string id) =>
        await _carInsuranceCollection.Find(doc => doc.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Insurance carInsurance) =>
        await _carInsuranceCollection.InsertOneAsync(carInsurance);

    public async Task UpdateAsync(string id, Insurance updatedCarInsurance) =>
        await _carInsuranceCollection.ReplaceOneAsync(doc => doc.Id == id, updatedCarInsurance);

    public async Task RemoveAsync(string id) =>
        await _carInsuranceCollection.DeleteOneAsync(doc => doc.Id == id);
}
