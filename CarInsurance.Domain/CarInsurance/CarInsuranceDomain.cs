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
            Policy? policy = await _carPoliciesRepository.GetAsync(doc => doc.Name == carInsurance.Policy.Name);

                Debug.Assert(policy?.Amount == 0);

            if (policy is null)
                return null;

            if (policy.ExpirationDate < carInsurance.CreationDate)
                return false;

            carInsurance.Policy = new() {
                Id = policy.Id,
                Amount = policy.Amount,
                CreationDate = policy.CreationDate,
                ExpirationDate= policy.ExpirationDate            
            };

            await _carInsuranceRepository.CreateAsync(carInsurance);

            return true;
        }
    }
}