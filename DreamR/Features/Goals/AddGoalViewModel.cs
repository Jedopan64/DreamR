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

        [Required]
        public bool IsPrivate{get;set;}
        [Required]
        public bool IsCompleted{get;set;}      
    }
}