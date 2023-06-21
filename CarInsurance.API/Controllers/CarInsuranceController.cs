using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.CarInsurance;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarInsurance.API.Controllers;

//[Authorize]
[Controller]
[Route("api/[controller]")]
public class CarInsuranceController : Controller
{
    private readonly ICarInsuranceRepository _carInsuranceRepository;
    private readonly ICarInsuranceDomain _carInsuranceDomain;

    public CarInsuranceController(ICarInsuranceRepository repository, ICarInsuranceDomain carInsuranceDomain)
    {
        _carInsuranceRepository = repository;
        _carInsuranceDomain = carInsuranceDomain;
    }

    [HttpGet]
    public async Task<List<Insurance>> Get() =>
        await _carInsuranceRepository.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Insurance>> Get(string id)
    {
        var result = await _carInsuranceRepository.GetAsync(id);

        if (result is null) return NotFound();

        return result;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Insurance newCarInsurance)
    {
        Debug.Assert(newCarInsurance != null);
        var result = await _carInsuranceDomain.CreateAsync(newCarInsurance);

        if (result is null) return NotFound("Can't create insurance. Policy does not exist.");

        if (result is false) return BadRequest("Can't create insurance. Policy has expired.");

        return CreatedAtAction(nameof(Get), new { id = newCarInsurance.Id }, newCarInsurance);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Insurance updatedCarInsurance)
    {
        var result = await _carInsuranceRepository.GetAsync(id);

        if (result is null)return NotFound();

        updatedCarInsurance.Id = result.Id;

        await _carInsuranceRepository.UpdateAsync(id, updatedCarInsurance);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _carInsuranceRepository.GetAsync(id);
        
        if (result is null) return NotFound();

        await _carInsuranceRepository.RemoveAsync(id);

        return NoContent();
    }

}