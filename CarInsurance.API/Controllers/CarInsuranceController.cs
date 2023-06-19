using CarInsurance.API.Middleware.AuthJWT.Helpers;
using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.CarInsurance;
using CarInsurance.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarInsurance.API.Controllers;

[Authorize]
[Controller]
[Route("api/[controller]")]
public class CarInsuranceController : Controller
{
    private readonly CarPoliciesService _carPoliciesService;
    private readonly ICarInsuranceRepository _repository;

    public CarInsuranceController(ICarInsuranceRepository repository, CarPoliciesService carPoliciesService)
    {
        _repository = repository;
        _carPoliciesService = carPoliciesService;

        carPoliciesService.Initialize();
    }

    [HttpGet]
    public async Task<List<Insurance>> Get() =>
        await _repository.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Insurance>> Get(string id)
    {
        var result = await _repository.GetAsync(id);

        if (result is null) return NotFound();

        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Insurance newCarInsurance)
    {
        await _repository.CreateAsync(newCarInsurance);

        return CreatedAtAction(nameof(Get), new { id = newCarInsurance.Id }, newCarInsurance);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Insurance updatedCarInsurance)
    {
        var result = await _repository.GetAsync(id);

        if (result is null)return NotFound();

        updatedCarInsurance.Id = result.Id;

        await _repository.UpdateAsync(id, updatedCarInsurance);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _repository.GetAsync(id);
        
        if (result is null) return NotFound();

        await _repository.RemoveAsync(id);

        return NoContent();
    }

}