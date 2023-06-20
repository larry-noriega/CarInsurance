using CarInsurance.Core.Models.CarInsurance;

namespace CarInsurance.Core.Interfaces;

public interface ICarInsuranceDomain
{
    Task<bool?> CheckAbility(Insurance carInsurance);
}