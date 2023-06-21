using CarInsurance.Core.Enums;
using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models;
using CarInsurance.Core.Models.CarInsurance;

namespace CarInsurance.Domain.Processor;
public class CarInsuranceProcessor
{
    private ICarInsuranceDomain _carInsuranceDomain;

    public CarInsuranceProcessor(ICarInsuranceDomain carInsuranceDomain)
    {
        _carInsuranceDomain = carInsuranceDomain;
    }

    public CarInsuranceResult? CreateAsync(CarInsuranceRequest? carInsuranceRequest)
    {
        if (carInsuranceRequest is null) throw new ArgumentNullException(nameof(CarInsuranceRequest));

        Task<bool?> policy = _carInsuranceDomain.CreateAsync(carInsuranceRequest);

        policy.Wait();

        bool? isValid = policy.Result;

        var result = CreateCarInsuranceObject<CarInsuranceResult>(carInsuranceRequest);

        if (isValid is null)
            return null;

        if (isValid is false)
        {
            result.Flag = CarInsuranceResultFlag.Failure;
            return result;        
        }

        result.Flag = CarInsuranceResultFlag.Success;

        return result;
    }

    private static TCarInsurance CreateCarInsuranceObject<TCarInsurance>(CarInsuranceRequest carInsuranceRequest) where TCarInsurance : Insurance, new()
    {
        return new TCarInsurance
        {
            Policy = new()
            {
                Id = carInsuranceRequest.Policy.Id,
                Name = carInsuranceRequest.Policy.Name,
                Coverage = carInsuranceRequest.Policy.Coverage,
                Amount = carInsuranceRequest.Policy.Amount,
                CreationDate = carInsuranceRequest.Policy.CreationDate,
                ExpirationDate = carInsuranceRequest.Policy.ExpirationDate,
            }
        };
    }


}
