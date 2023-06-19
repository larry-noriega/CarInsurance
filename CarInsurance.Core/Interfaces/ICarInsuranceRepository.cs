using CarInsurance.Core.Models.CarInsurance;

namespace CarInsurance.Core.Interfaces
{
    public interface ICarInsuranceRepository
    {
        Task CreateAsync(Insurance carInsurance);
        Task<List<Insurance>> GetAsync();
        Task<Insurance?> GetAsync(string id);
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, Insurance updatedCarInsurance);
    }
}