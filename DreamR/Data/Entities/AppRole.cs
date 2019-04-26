using Microsoft.AspNetCore.Identity;

namespace DreamR.Data.Entities
{
    /// <summary>
    /// Role class Entity
    /// </summary> 
    public class AppRole : IdentityRole<int>
    {
        
        public AppRole() { }

        public AppRole(string name)
        {
            Name = name;
        }
    }
}