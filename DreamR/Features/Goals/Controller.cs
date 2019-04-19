using System.Threading.Tasks;
using DreamR.Data;
using DreamR.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DreamR.Features.Goals
{
  [Route("api/[controller]")]
  public class GoalsController : Controller
  {  
      private readonly DataContext db;
  
    public GoalsController(DataContext db)
    {
      this.db = db;
    }
    

  [HttpPost]
  public async Task<IActionResult> AddGoal([FromBody] AddGoalViewModel model)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var goal = new Goal
    {
      Title = model.Title;
    };
    

    var registerResult = await _userManager.CreateAsync(user, model.Password);   

    if (!registerResult.Succeeded)
      return BadRequest(registerResult.Errors);

    await _userManager.AddToRoleAsync(user, "Customer");

    return Ok();
  }
}
}