using Microsoft.AspNetCore.Identity;

namespace UserManager.Infra.CrossCutting.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public bool Status { get; set; }
    }
}