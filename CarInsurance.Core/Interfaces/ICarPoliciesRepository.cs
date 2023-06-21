using CarInsurance.Core.Models.CarPolicy;
using System.Linq.Expressions;

namespace CarInsurance.Core.Interfaces;

public interface ICarPoliciesRepository
{
    Task CreateAsync(Policy carPolicy);
    Task<List<Policy>> GetAsync();
    Task<Policy?> GetAsync(Expression<Func<Policy, bool>> filter);
    Task RemoveAsync(string id);
    Task UpdateAsync(string id, Policy updatedCarPolicy);    
}