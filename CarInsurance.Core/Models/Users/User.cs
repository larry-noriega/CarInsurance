using System.Text.Json.Serialization;

namespace CarInsurance.Core.Models.Users;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Username { get; set; } = null!;

    [JsonIgnore]
    public string Password { get; set; } = null!;
}