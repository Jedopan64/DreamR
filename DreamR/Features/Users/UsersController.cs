using System.Threading.Tasks;
using DreamR.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamR.Features.Users
{
  [Authorize]
  [Route("api/[controller]")]
  public class UsersController : Controller
  {
    private readonly DataContext _db;

    public UsersController(DataContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _db.Users.ToListAsync());
    }
  }
}
