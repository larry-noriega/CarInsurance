namespace CarInsurance.Core.Models.CarPolicy;

public class Policy : Document
{
    public string Name { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    private DateTime creationDate;
    public DateTime ExpirationDate
    {
        get
        {
            creationDate = CreationDate.AddMonths(Random.Shared.Next(5, 9));

            return creationDate;
        }
        set => creationDate = value;
    }
}
