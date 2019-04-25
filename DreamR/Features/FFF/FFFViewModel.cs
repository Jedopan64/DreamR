using DreamR.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System.Web.Http;

namespace DreamR.Features.FFF
{
    public class FFFViewModel
    {
        public IFormCollection GoalImageFile{get;set;}                   
    }
}