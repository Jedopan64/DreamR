using System.Threading.Tasks;
using DreamR.Data;
using DreamR.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System;

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
      Title = model.Title,
      Category = model.Category,
      Placed = model.Placed,
      DeadLine = model.DeadLine,
      Description = model.Description,
      IsCompleted = model.IsCompleted,
      IsPrivate = model.IsPrivate
    };
    

     db.Goal.Add(goal);   
     await db.SaveChangesAsync();

    var userId =  User.FindFirst(ClaimTypes.NameIdentifier).Value;

    var usergoal = new UsersGoal
    {
      GoalId = goal.GoalId,   
      UserId = Int32.Parse(userId)
    };

    db.UsersGoal.Add(usergoal);
    await db.SaveChangesAsync();

    return Ok();
  }
}
}