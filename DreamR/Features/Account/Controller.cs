using System.Threading.Tasks;
using DreamR.Data;
using DreamR.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DreamR.Features.Account
{
  [Route("api/[controller]")]
  public class AccountController : Controller
  {
    private readonly UserManager<AppUser> _userManager;

  
    public AccountController(UserManager<AppUser> userManager)
    {
      _userManager = userManager;
    }
    

  [HttpPost]
  public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var user = await _userManager.FindByEmailAsync(model.Email);

    if (user != null)
      return BadRequest("A user with that e-mail address already exists!");

    user = new AppUser
    {
      UserName = model.UserName,
      Email = model.Email,
      EmailConfirmed = true,      
      LockoutEnabled = true
    };
    if(!model.Password.Any(char.IsUpper))
      return BadRequest("Password requires at least one uppercase letter");
    if(!model.Password.Any(char.IsSymbol))
      return BadRequest("Password requires at least one special character");
    if(!model.Password.Any(char.IsDigit))
      return BadRequest("Password requires at least one digit");
    if(!model.Password.Any(char.IsLower))
      return BadRequest("Password requires at least one lowercase letter");

    var registerResult = await _userManager.CreateAsync(user, model.Password);   

    if (!registerResult.Succeeded)
      return BadRequest(registerResult.Errors);

    await _userManager.AddToRoleAsync(user, "Customer");

    return Ok();
  }
}
}
