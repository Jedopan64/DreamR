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
      AddCategory(context);    
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
      if (UserManager.FindByEmailAsync("johnSmith@gmail.com").GetAwaiter().GetResult() == null)
      {
        var user = new AppUser
        {          
          UserName = "JonnyS11",
          Email = "johnSmith@gmail.com",
          EmailConfirmed = true,
          LockoutEnabled = false
        };

        UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
      }

      var admin = UserManager.FindByEmailAsync("johnSmith@gmail.com").GetAwaiter().GetResult();

      if (UserManager.IsInRoleAsync(admin, "Admin").GetAwaiter().GetResult() == false)
      {
        UserManager.AddToRoleAsync(admin, "Admin");
      }
      
      if (UserManager.FindByEmailAsync("mariobros@gmail.com").GetAwaiter().GetResult() == null)
      {
        var user = new AppUser
        {
          UserName = "Mario420",
          Email = "mariobros@gmail.com",
          EmailConfirmed = true,
          LockoutEnabled = true
        };

        UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
      }

      var client = UserManager.FindByEmailAsync("mariobros@gmail.com").GetAwaiter().GetResult();

      if (UserManager.IsInRoleAsync(client, "Customer").GetAwaiter().GetResult() == false)
      {
        UserManager.AddToRoleAsync(client, "Customer");
      }
    } 

    public static void AddCategory(DataContext context)
    {
      if (context.Category.Any() == false)
      {
        var category = new List<string>() { "Travel", "Food", "Sport","Home" };

        category.ForEach(c => context.Category.Add(new Category
        {
          CategoryName = c
        }));

        context.SaveChanges();
      }
    }  
  }
}