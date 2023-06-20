using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.CarInsurance;
using CarInsurance.Core.Models.CarPolicy;
using System.Diagnostics;

namespace CarInsurance.Domain.CarInsurance
{
    public class CarInsuranceDomain : ICarInsuranceDomain
    {
        private readonly ICarInsuranceRepository _carInsuranceRepository;
        private readonly ICarPoliciesRepository _carPoliciesRepository;

        public CarInsuranceDomain(
            ICarInsuranceRepository carInsuranceRepository, ICarPoliciesRepository carPoliciesRepository)
        {
            _carInsuranceRepository = carInsuranceRepository;
            _carPoliciesRepository = carPoliciesRepository;
        }

        public async Task<bool?> CreateAsync(Insurance carInsurance)
        {
            var hosted = carInsurance;

            Policy? policy = await _carPoliciesRepository.GetAsync(doc => doc.Name == carInsurance.Policy.Name);

            if (policy is null)
                return null;

            if (policy.ExpirationDate < carInsurance.CreationDate)
                return false;

            carInsurance.Policy.Id = policy.Id;
            carInsurance.Policy.CreationDate = policy.CreationDate;
            carInsurance.Policy.ExpirationDate= policy.ExpirationDate;

            await _carInsuranceRepository.CreateAsync(carInsurance);

            return true; //Insurance created.
        }
    }
}