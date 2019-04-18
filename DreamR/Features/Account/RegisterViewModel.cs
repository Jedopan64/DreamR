using System.ComponentModel.DataAnnotations;

namespace DreamR.Features.Account
{
  public class RegisterViewModel
  {
    [Required]
    public string UserName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
  }
}