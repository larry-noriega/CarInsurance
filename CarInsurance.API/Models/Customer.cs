namespace CarInsurance.API.Models;

public class Customer
{
    public string Name { get; set; } = null!;

    public string ID { get; set; } = null!;

    public DateTime ClientBirthDate { get; set; }

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;
}
