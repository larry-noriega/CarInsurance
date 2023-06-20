namespace CarInsurance.Core.Models.CarPolicy;

public class Policy : Document
{
    public string Name { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    private DateTime expirationDate;
    public DateTime ExpirationDate
    {
        get
        {
            expirationDate = CreationDate.AddMonths(Random.Shared.Next(5, 9));

            return expirationDate;
        }
        set => expirationDate = value;
    }
}
