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

        List<string> coverage = new()
        {
            "Liability coverage",
            "Uninsured/underinsured motorist (UM) coverage",
            "Personal injury protection (PIP)",
            "Medical payment coverage",
            "Comprehensive and collision coverage"
        };

        return new List<Policy>()
        {
            new Policy
            {
                Name = "Archibald",
                Coverage = GetRandomElements(coverage, Random.Shared.Next(1, coverage.Count)),
                CreationDate = DateTime.Today.AddMonths(creationDate)
            },
            new Policy
            {
                Name = "Farrago",
                Coverage =  GetRandomElements(coverage, Random.Shared.Next(1, coverage.Count)),
                CreationDate = DateTime.Today
            },
            new Policy
            {
                Name = "Marcie",
                Coverage = GetRandomElements(coverage, Random.Shared.Next(1, coverage.Count)),
                CreationDate = DateTime.Today.AddMonths(creationDate)
            },
            new Policy
            {
                Name = "Luke",
                Coverage = GetRandomElements(coverage, Random.Shared.Next(1, coverage.Count)), 
                CreationDate = DateTime.Today.AddMonths(creationDate)
            },
            new Policy
            {
                Name = "Yasmin",
                Coverage = GetRandomElements(coverage, Random.Shared.Next(1, coverage.Count)),
                CreationDate = DateTime.Today.AddMonths(creationDate)
            },
            new Policy
            {
                Name = "Savage",
                Coverage = GetRandomElements(coverage, Random.Shared.Next(1, coverage.Count)),
                CreationDate = DateTime.Today.AddMonths(creationDate)
            }
        };
    }

    private void RemovePolicies() => _context.CarPolicies.DeleteMany(_ => true);
    private void CreatePolicies(List<Policy> policies) => _context.CarPolicies.InsertMany(policies);

    public static List<T> GetRandomElements<T>(List<T> list, int elementsCount)
    {
        return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
    }
}
