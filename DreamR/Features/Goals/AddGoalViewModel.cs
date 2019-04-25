using DreamR.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Web.Http;

namespace DreamR.Features.Goals
{
    public class AddGoalViewModel
    {
        
        [Required]
        [StringLength(100)]
        public string Title{get;set;}
        [Required]
        public string Category{get;set;}    

        [Required]
        public DateTime Placed { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime DeadLine{get;set;}

        public string Description{get;set;}    

        public string GoalImageURL{get;set;} 
        public string GoalImageBinary{get;set;}   
                
        [Required]
        public bool IsPrivate{get;set;}
        [Required]
        public bool IsCompleted{get;set;} 
            
    }
}