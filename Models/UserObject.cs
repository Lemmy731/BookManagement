using Microsoft.AspNetCore.Identity;

namespace BookManagemant.Models
{
    public class UserObject : IdentityUser
    {
        //public int Id { get; set; }
        //public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
    }

    public class Role : IdentityRole
    {
        public string RoleName { get; set; } = "Member";
    }
}
