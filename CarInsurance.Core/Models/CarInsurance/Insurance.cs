using CarInsurance.Core.Models.CarPolicy;

namespace CarInsurance.Core.Models.CarInsurance;

public class Insurance : Document
{
    public double Amount { get; set; }

    public string[] Coverage { get; set; } = null!;

    public Customer Customer { get; set; } = null!;

    public Car Car { get; set; } = null!;

    public Policy Policy { get; set; } = null!;    

    private DateTime creationDate;
    public DateTime CreationDate
    {
        get
        {
            creationDate = DateTime.Today;

            return creationDate;
        }
        set => creationDate = value;
    }   
}
