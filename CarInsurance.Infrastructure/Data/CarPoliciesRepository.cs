using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.CarPolicy;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace CarInsurance.Infrastructure.Data;

public class CarPoliciesRepository : ICarPoliciesRepository
{
    private readonly ICarPoliciesContext _context;

    public CarPoliciesRepository(ICarPoliciesContext context)
    {
        _context = context;
    }

    public async Task<List<Policy>> GetAsync() =>
        await _context.CarPolicies.Find(_ => true).ToListAsync();

    public async Task<Policy?> GetAsync(Expression<Func<Policy, bool>> filter) =>
       await _context.CarPolicies.Find(filter).FirstOrDefaultAsync();

    public void RemovePolicies() => _context.CarPolicies.DeleteMany(_ => true);

    public void CreatePolicies(List<Policy> policies) => _context.CarPolicies.InsertMany(policies);

}
