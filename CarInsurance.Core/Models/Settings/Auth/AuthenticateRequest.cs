using System.ComponentModel.DataAnnotations;

namespace CarInsurance.Core.Models.Settings.Auth;

public class AuthenticateRequest
{
  [Required]
  public string Username { get; set; } = null!;

  [Required]
  public string Password { get; set; } = null!;
}