namespace CarInsurance.Core.Models.CarPolicy;

public class Car
{
    public string Plate { get; set; } = null!;

    public string Model { get; set; } = null!;

    public bool Inspection { get; set; }
}