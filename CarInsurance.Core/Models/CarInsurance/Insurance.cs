namespace CarInsurance.Core.Models.CarInsurance;

public class Insurance : Document
{
    public decimal Number { get; set; }

    public decimal Amount { get; set; }

    public string[] Coverage { get; set; } = null!;

    public Customer Customer { get; set; } = null!;

    public Car Car { get; set; } = null!;

    public DateTime InsuranceCreationDate { get; set; }
}
