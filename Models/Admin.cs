using Microsoft.AspNetCore.Identity;

namespace UranusAdmin.Models
{
    public class Admin : IdentityUser
    {
        public override string? UserName { get; set; }
    }
}
