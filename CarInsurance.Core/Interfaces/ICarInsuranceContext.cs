using CarInsurance.Core.Models.CarInsurance;
using MongoDB.Driver;

namespace CarInsurance.Core.Interfaces;

public interface ICarInsuranceContext
{
    IMongoCollection<Insurance> CarInsurance { get; }
}