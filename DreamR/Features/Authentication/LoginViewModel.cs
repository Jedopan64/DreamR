using System.ComponentModel.DataAnnotations;

namespace DreamR.Features.Authentication
{
  ///<summary>
  /// ViewModel for user authentication
  ///</summary>
  public class LoginViewModel
  {
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
  }
}