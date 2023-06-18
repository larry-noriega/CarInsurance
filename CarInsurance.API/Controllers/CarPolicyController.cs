using CarInsurance.API.Models;
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
    public async Task<List<CarPolicy>> Get() =>
        await _carPolicyService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<CarPolicy>> Get(string id)
    {
        var result = await _carPolicyService.GetAsync(id);

        if (result is null) return NotFound();

        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CarPolicy newCarPolicy)
    {
        await _carPolicyService.CreateAsync(newCarPolicy);

        return CreatedAtAction(nameof(Get), new { id = newCarPolicy.Id }, newCarPolicy);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, CarPolicy updatedPolicy)
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