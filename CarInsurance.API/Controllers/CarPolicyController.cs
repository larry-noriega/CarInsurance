using CarInsurance.Core.Models.CarPolicy;
using CarInsurance.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarInsurance.API.Controllers;

[Controller]
[Route("api/[controller]")]
public class CarPolicyController : Controller
{

    private readonly CarPoliciesService _carPolicyService;

    public CarPolicyController(CarPoliciesService carPoliciesService) =>
        _carPolicyService = carPoliciesService;


    [HttpGet]
    public async Task<List<CarPolicyModel>> Get() =>
        await _carPolicyService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<CarPolicyModel>> Get(string id)
    {
        var result = await _carPolicyService.GetAsync(id);

        if (result is null) return NotFound();

        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CarPolicyModel newCarPolicy)
    {
        await _carPolicyService.CreateAsync(newCarPolicy);

        return CreatedAtAction(nameof(Get), new { id = newCarPolicy.Id }, newCarPolicy);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, CarPolicyModel updatedPolicy)
    {
        var result = await _carPolicyService.GetAsync(id);

        if (result is null)return NotFound();

        updatedPolicy.Id = result.Id;

        await _carPolicyService.UpdateAsync(id, updatedPolicy);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _carPolicyService.GetAsync(id);
        
        if (result is null) return NotFound();

        await _carPolicyService.RemoveAsync(id);

        return NoContent();
    }

}