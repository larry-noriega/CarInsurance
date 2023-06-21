using System.ComponentModel.DataAnnotations;
using CarInsurance.Core.Interfaces;

namespace CarInsurance.Core.Models.CarPolicy;

public class Policy : IDocument
{
    [Required]
    public string Name { get; set; }

    public List<string> Coverage { get; set; } = new List<string>();

    private decimal amount;
    public decimal Amount
    {
        get
        {
            if (Coverage.Count == 5)
            {
                amount = 2014;
                return amount;
            }

            if (Coverage.Count <= 4 && Coverage.Count >= 3)
            {
                amount = Random.Shared.Next(1300, 1900);
                return amount;
            }
                
            amount = Random.Shared.Next(1007, 1200);            
            return amount;
        }
        set => amount = value;
    }   

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


