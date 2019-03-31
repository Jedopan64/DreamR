using Microsoft.AspNetCore.Identity;


namespace DreamRF.Data.Entities
{
public class RoleDto : IdentityRole<int>
    {
        public RoleDto() { }

        public RoleDto(string name)
        {
            Name = name;
        }
    }
}