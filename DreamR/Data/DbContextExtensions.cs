using System;
using System.Collections.Generic;
using System.Linq;
using DreamR.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DreamR.Data
{
  public static class DbContextExtensions
  {
    public static RoleManager<AppRole> RoleManager { get; set; }
    public static UserManager<AppUser> UserManager { get; set; }

    public static void EnsureSeeded(this DataContext context)
    {
      AddRoles(context);
      AddUsers(context);      
    }

    private static void AddRoles(DataContext context)
    {
      if (RoleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult() == false)
      {
        RoleManager.CreateAsync(new AppRole("Admin")).GetAwaiter().GetResult();
      }

      if (RoleManager.RoleExistsAsync("Customer").GetAwaiter().GetResult() == false)
      {
        RoleManager.CreateAsync(new AppRole("Customer")).GetAwaiter().GetResult();
      }
    }

    private static void AddUsers(DataContext context)
    {
      if (UserManager.FindByEmailAsync("stu@ratcliffe.io").GetAwaiter().GetResult() == null)
      {
        var user = new AppUser
        {
          FirstName = "Stu",
          LastName = "Ratcliffe",
          UserName = "stu@ratcliffe.io",
          Email = "stu@ratcliffe.io",
          EmailConfirmed = true,
          LockoutEnabled = false
        };

        UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
      }

      var admin = UserManager.FindByEmailAsync("stu@ratcliffe.io").GetAwaiter().GetResult();

      if (UserManager.IsInRoleAsync(admin, "Admin").GetAwaiter().GetResult() == false)
      {
        UserManager.AddToRoleAsync(admin, "Admin");
      }
    }   
  }
}