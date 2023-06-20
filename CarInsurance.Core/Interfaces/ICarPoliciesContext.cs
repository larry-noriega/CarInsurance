using CarInsurance.Core.Models.CarPolicy;
using MongoDB.Driver;

namespace CarInsurance.Core.Interfaces;

public interface ICarPoliciesContext
{
    IMongoCollection<Policy> CarPolicies { get; }
}