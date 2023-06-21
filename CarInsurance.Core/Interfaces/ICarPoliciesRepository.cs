using CarInsurance.Core.Models.CarPolicy;
using System.Linq.Expressions;

namespace CarInsurance.Core.Interfaces;

public interface ICarPoliciesRepository
{
    Task<List<Policy>> GetAsync();
    Task<Policy?> GetAsync(Expression<Func<Policy, bool>> filter);
    void CreatePolicies(List<Policy> policies);
    void RemovePolicies();
}