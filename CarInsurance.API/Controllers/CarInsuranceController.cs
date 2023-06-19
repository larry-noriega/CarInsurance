using CarInsurance.Core.Models.CarPolicy;
using CarInsurance.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarInsurance.API.Controllers;

[Controller]
[Route("api/[controller]")]
public class CarInsuranceController : Controller
{
    private readonly CarInsuranceService _carInsuranceService;

    public CarInsuranceController(CarInsuranceService carInsuranceService) =>
        _carInsuranceService = carInsuranceService;


    [HttpGet]
    public async Task<List<Insurance>> Get() =>
        await _carInsuranceService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Insurance>> Get(string id)
    {
        var result = await _carInsuranceService.GetAsync(id);

        if (result is null) return NotFound();

        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Insurance newCarInsurance)
    {
        await _carInsuranceService.CreateAsync(newCarInsurance);

        return CreatedAtAction(nameof(Get), new { id = newCarInsurance.Id }, newCarInsurance);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Insurance updatedCarInsurance)
    {
        var result = await _carInsuranceService.GetAsync(id);

        if (result is null)return NotFound();

        updatedCarInsurance.Id = result.Id;

        await _carInsuranceService.UpdateAsync(id, updatedCarInsurance);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _carInsuranceService.GetAsync(id);
        
        if (result is null) return NotFound();

        await _carInsuranceService.RemoveAsync(id);

        return NoContent();
    }

}