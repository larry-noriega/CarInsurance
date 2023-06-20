using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.CarInsurance;
using CarInsurance.Core.Models.CarPolicy;

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

        public async Task<bool?> CheckAbility(Insurance carInsurance)
        {
            Policy? policy = await _carPoliciesRepository.GetAsync(doc => doc.Name == carInsurance.Policy.Name);

            if (policy is null) return null;

            if (policy.ExpirationDate < carInsurance.CreationDate) return false;

            await _carInsuranceRepository.CreateAsync(carInsurance);

            return true;
        }
    }
}