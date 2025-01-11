using Microsoft.AspNetCore.Identity;

namespace AisLogistics.App.Data
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string roleName) : base(roleName)
        {
            Name = roleName;
        }

        public string? Description { get; set; }
    }
}
