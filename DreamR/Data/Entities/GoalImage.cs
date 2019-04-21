using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DreamR.Data.Entities
{
    public class GoalImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GoalImageId{get;set;}
        [Required]
        [StringLength(15)]
        public string GoalImagePath{get;set;}
    }
}

