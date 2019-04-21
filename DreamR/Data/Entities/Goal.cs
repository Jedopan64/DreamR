using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace DreamR.Data.Entities
{
    public class Goal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoalId{get; set;}
        [Required]
        [StringLength(100)]
        public string Title{get;set;}
        [Required]        
        public int CategoryId { get; set; }
        public Category Category { get; set; }       

        [Required]
        public DateTime Placed { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime DeadLine{get;set;}

        public string Description{get;set;}

        [Required]
        public bool IsPrivate{get;set;}
        [Required]
        public bool IsCompleted{get;set;}     

         

        public List<UsersGoal> UsersGoal = new List<UsersGoal>();  
    }
}
