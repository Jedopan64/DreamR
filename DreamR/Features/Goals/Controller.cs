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
using static System.IO.StreamWriter;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Web.Http;
using System.Net;
using  Microsoft.AspNetCore.Hosting;
using static Microsoft.AspNetCore.Hosting.Internal.HostingEnvironment;


namespace DreamR.Features.Goals
{
  /// <summary>
  /// Controller for Goals
  /// </summary>
  [Route("api/[controller]")]
  public class GoalsController : Controller
  {  
      private readonly DataContext db;
      private readonly IHostingEnvironment env;

    /// <summary>
    /// Used for injecting dependencies for GoalController
    /// </summary>
    /// <parma name="db">Type='DataContext'. Loads and manages database entities</param>
    /// <parma name="env">Type='IHostingEnvironment'. Provides information about the web hosting environment an application is running in</param>
    public GoalsController(DataContext db, IHostingEnvironment env)
    {
      this.env = env;
      this.db = db;
    }
    
    /// <summary>
    /// Add goal and assign it to user
    /// </summary>
    /// <parma name="model">Type='AddGoalViewModel'. Contenins Goal data given by user</param>
    [HttpPost]
    public async Task<IActionResult> AddGoal([FromBody] AddGoalViewModel model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState); 

      string filename="";
      if(model.GoalImageBinary!=null)
      {
      var webroot = env.WebRootPath+"\\uploads\\goalImages"; 
      filename = DateTime.Now.ToString("yymmssffff")+".txt";
      filename = Path.Combine(webroot,filename);
      using (StreamWriter sw = System.IO.File.CreateText(filename)) 
              {
                  sw.WriteLine(model.GoalImageBinary);                
              }	
      }
      
      var goal = new Goal
      {
        Title = model.Title,
        Category = db.Category.Single(c => c.CategoryName== model.Category),
        Placed = model.Placed,
        DeadLine = model.DeadLine,
        Description = model.Description,
        GoalImageBinary = filename,
        IsCompleted = model.IsCompleted,
        IsPrivate = model.IsPrivate,      
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