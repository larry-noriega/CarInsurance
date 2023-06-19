using CarInsurance.Core.Models.CarPolicy;
using MongoDB.Driver;

namespace CarInsurance.Core.Interfaces;

public interface ICarPolicyContext
{
    IMongoCollection<Policy> CarInsurance { get; }
}