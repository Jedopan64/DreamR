using System.Threading.Tasks;
using DreamR.Data;
using DreamR.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.IO;
using static System.IO.File;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Web.Http;
using System.Net;
using  Microsoft.AspNetCore.Hosting;
using static Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment;


namespace DreamR.Features.Goals
{
  [Route("api/[controller]")]
  public class GoalsController : Controller
  {  
      private readonly DataContext db;
      private readonly IHostingEnvironment env;
  
    public GoalsController(DataContext db, IHostingEnvironment env)
    {
      this.env = env;
      this.db = db;
    }
    

  [HttpPost]
  public async Task<IActionResult> AddGoal([FromBody] AddGoalViewModel model)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);    
      
    /*
    string filename = Path.GetFileNameWithoutExtension(model.GoalImageFile.FileName);
    string extension = Path.GetExtension(model.GoalImageFile.FileName);
    filename = filename + DateTime.Now.ToString("yymmssffff")+extension;
    var webroot = env.WebRootPath;    
    filename = Path.Combine(webroot,filename);

    model.GoalImageFile.CopyTo(new FileStream(filename, FileMode.Create));  
    */
      
    
    var goal = new Goal
    {
      Title = model.Title,
      Category = db.Category.Single(c => c.CategoryName== model.Category),
      Placed = model.Placed,
      DeadLine = model.DeadLine,
      Description = model.Description,
      IsCompleted = model.IsCompleted,
      IsPrivate = model.IsPrivate
    };
    

     db.Goal.Add(goal);   
     await db.SaveChangesAsync();

    var user = await db.Users.SingleAsync(x => x.UserName == HttpContext.User.Identity.Name);

    var usergoal = new UsersGoal
    {
      Goal = goal,   
      AppUser = user
    };

    db.UsersGoal.Add(usergoal);
    await db.SaveChangesAsync();
    

    //retrun Json("Goal added!")
    return Ok();
  }
}
}