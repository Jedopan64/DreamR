using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamR.Data.Entities
{
    public class UsersGoal
    {
        [Key]
        [Required]
        public int GoalId{get;set;}
        public Goal Goal{get;set;}
        [Key]        
        [Required]
        [ForeignKey("AppUser")]
        public int UserId{get;set;}
        public AppUser AppUser{get;set;}
    }
}