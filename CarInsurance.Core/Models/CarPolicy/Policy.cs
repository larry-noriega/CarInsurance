using System.ComponentModel.DataAnnotations;

namespace CarInsurance.Core.Models.CarPolicy;

public class Policy : Document
{
    [Required]
    public string Name { get; set; }

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
