using CarInsurance.Core.Enums;
using CarInsurance.Core.Models.CarInsurance;

namespace CarInsurance.Core.Models;

public class CarInsuranceResult : Insurance
{
    public CarInsuranceResultFlag? Flag { get; set; }
}