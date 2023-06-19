using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.CarInsurance;
using MongoDB.Driver;

namespace CarInsurance.Infrastructure.Data;

public class CarInsuranceRepository : ICarInsuranceRepository
{
    private readonly ICarInsuranceContext _context;

    public CarInsuranceRepository(ICarInsuranceContext context)
    {
        _context = context;
    }

    public async Task<List<Insurance>> GetAsync() => 
        await _context.CarInsurance.Find(_ => true).ToListAsync();

    public async Task<Insurance?> GetAsync(string id) =>
        await _context.CarInsurance.Find(doc => doc.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Insurance carInsurance) =>
        await _context.CarInsurance.InsertOneAsync(carInsurance);

    public async Task UpdateAsync(string id, Insurance updatedCarInsurance) => await _context.CarInsurance.ReplaceOneAsync(doc => doc.Id == id, updatedCarInsurance);

    public async Task RemoveAsync(string id) =>
        await _context.CarInsurance.DeleteOneAsync(doc => doc.Id == id);

}
