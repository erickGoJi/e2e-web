using Microsoft.AspNetCore.Identity;

namespace e2e.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string EmployeeNumber { get; set; }
        public bool IsFirstAttempt { get; set; }
    }

}
