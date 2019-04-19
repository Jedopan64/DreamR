using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DreamR.Data.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public List<UsersGoal> UsersGoal = new List<UsersGoal>();  
    }
}