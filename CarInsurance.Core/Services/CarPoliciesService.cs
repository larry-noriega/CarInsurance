using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.CarPolicy;
using MongoDB.Driver;

namespace CarInsurance.Core.Services;

public class CarPoliciesService
{
    private readonly ICarPolicyContext _context;

    public CarPoliciesService(ICarPolicyContext context)
    {
        _context = context;
    }   

    public void Initialize()
    {
        RemovePolicies();

        CreatePolicies(InitialData());
    }

    private void RemovePolicies() => _context.CarInsurance.DeleteMany(_ => true);
    private void CreatePolicies(Policy[] policies) => _context.CarInsurance.InsertMany(policies);

    public static List<Policy> InitialData()
    {
        int creationDate = Random.Shared.Next(-10, 9);

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

}
