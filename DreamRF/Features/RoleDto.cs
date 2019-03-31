using Microsoft.AspNetCore.Identity;


namespace DreamRF.Features
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