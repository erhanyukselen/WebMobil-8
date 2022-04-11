using Microsoft.AspNetCore.Identity;

namespace Identity101.Models.Identity
{
    public class ApplicationsUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
    }

    public class ApplicationRole : IdentityRole
    {
        public string? Description { get; set; }

        public ApplicationRole(string roleName, string description) : base(roleName)
        {
            this.Description = description;
        }

    }


}
