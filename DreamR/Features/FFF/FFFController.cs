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


namespace DreamR.Features.FFF
{
  [Route("api/[controller]")]
  public class FFFController : Controller
  {  
     
      private readonly IHostingEnvironment env;
  
    public FFFController(IHostingEnvironment env)
    {
      this.env = env;
      
    }
    

  [HttpPost]
  public async Task<IActionResult> AddFile([FromBody] FFFViewModel model)
  {
   
      Console.WriteLine("fsdfsadfsdfa0ffffffffffffffffff "+model.GoalImageFile.Count);
     /*
    string filename = Path.GetFileNameWithoutExtension(GoalImageFile.Files.FileName);
    string extension = Path.GetExtension(model.GoalImageFile.FileName);
    filename = filename + DateTime.Now.ToString("yymmssffff")+extension;
    var webroot = env.WebRootPath;    
    filename = Path.Combine(webroot,filename);

    model.GoalImageFile.CopyTo(new FileStream(filename, FileMode.Create));  
     
     */
    

    //retrun Json("Goal added!")
    return Ok();
  }
}
}