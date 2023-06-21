using CarInsurance.Core.Models.CarInsurance;

namespace CarInsurance.Core.Interfaces;

public interface ICarInsuranceDomain
{
    Task<bool?> CreateAsync(Insurance carInsurance);
}