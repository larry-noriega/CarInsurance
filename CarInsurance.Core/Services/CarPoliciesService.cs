using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.CarPolicy;
using MongoDB.Driver;

namespace CarInsurance.Core.Services;

public class CarPoliciesService : ICarPoliciesService
{
    private readonly ICarPoliciesContext _context;

    public CarPoliciesService(ICarPoliciesContext context)
    {
        _context = context;
    }

    public void InitializeDB()
    {
        RemovePolicies();

        CreatePolicies(InitialData());
    }

    public static List<Policy> InitialData()
    {
        int creationDate = Random.Shared.Next(-10, 0);

        return new List<Policy>()
        {
            new Policy
            {
                Name = "Archibald",
                CreationDate = DateTime.Today.AddMonths(creationDate)
            },
            new Policy
            {
                Name = "Farrago",
                CreationDate = DateTime.Today
            },
            new Policy
            {
                Name = "Marcie",
                CreationDate = DateTime.Today.AddMonths(creationDate)
            },
            new Policy
            {
                Name = "Luke",
                CreationDate = DateTime.Today.AddMonths(creationDate)
            },
            new Policy
            {
                Name = "Yasmin",
                CreationDate = DateTime.Today.AddMonths(creationDate)
            },
            new Policy
            {
                Name = "Savage",
                CreationDate = DateTime.Today.AddMonths(creationDate)
            }
        };
    }

    private void RemovePolicies() => _context.CarPolicies.DeleteMany(_ => true);
    private void CreatePolicies(List<Policy> policies) => _context.CarPolicies.InsertMany(policies);
}
