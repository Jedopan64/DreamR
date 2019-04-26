using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DreamR.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DreamR.Features.Authentication
{
  /// <summary>
  /// Controller for user authentication.  
  /// </summary>  
  [Route("api/[controller]")]
  public class TokenController : Controller
  {
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Used for injecting dependecies TokenController
    /// </summary>
    /// <parma name="signInManager">Type='SignInManager'. Validates supplied password</param>
    /// <parma name="userManager">Type='UserManager'. Loads and manages AppUser entitities</param>
    /// <parma name="configuration">Type='IConfiguration'. Reads the app settings needed to create a JWT</param>
    public TokenController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IConfiguration configuration)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _configuration = configuration;
    }

    /// <summary>
    /// Hendles the login request
    /// </summary>
    /// <param name="model">Type='LoginViewModel'. Contains email addres and password givem by user</parm>
    [HttpPost]
    public async Task<IActionResult> GetToken([FromBody] LoginViewModel model)
    {
      var errorMessage = "Invalid e-mail address and/or password";

      if (!ModelState.IsValid)
        return BadRequest(errorMessage);

      var user = await _userManager.FindByEmailAsync(model.Email);

      if (user == null)
        return BadRequest(errorMessage);

      if (await _userManager.IsLockedOutAsync(user))
        return BadRequest(errorMessage);

      var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

      if (!result.Succeeded)
        return BadRequest(errorMessage);
      // Generates token for valid user
      var token = await GenerateToken(user);

      return Ok(token);
    }
    
    /// <summary>
    /// Generates JWT after successful login attempt
    /// </summary>
    /// <parm name="user">Type='AppUser'. Authorized user</parma>
    private async Task<TokenViewModel> GenerateToken(AppUser user)
    {
      var claims = new List<Claim>
      {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, 
        Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName)
      };

      var roles = await _userManager.GetRolesAsync(user);

      foreach (var role in roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
      (_configuration["Authentication:JwtKey"]));
      var creds = new SigningCredentials(key,  
      SecurityAlgorithms.HmacSha256);
      var expires = DateTime.Now.AddDays(Convert.ToDouble
      (_configuration["Authentication:JwtExpireDays"]));

      var token = new JwtSecurityToken(
        _configuration["Authentication:JwtIssuer"],
        _configuration["Authentication:JwtAudience"],
        claims,
        expires: expires,
        signingCredentials: creds
      );

      return new TokenViewModel
      {
        AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
        AccessTokenExpiration = expires      
      };
    }
  }
}