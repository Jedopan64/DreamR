using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DreamR.Data.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId{get;set;}
        [Required]
        [StringLength(15)]
        public string CategoryName{get;set;}

        public List<Goal> Goals { get; set; } = new List<Goal>();
    }
}

