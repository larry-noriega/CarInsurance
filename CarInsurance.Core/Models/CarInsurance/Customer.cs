namespace CarInsurance.Core.Models.CarInsurance;

public class Customer : Document
{
    public string Name { get; set; } = null!;

    public decimal DocumentID { get; set; }

    public DateTime BirthDate { get; set; }

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;
}
