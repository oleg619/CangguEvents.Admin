using System.Linq;
using System.Threading.Tasks;
using CangguEvents.Admin.Web.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace CangguEvents.Admin.Web.Server
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            "".Distinct();
            // Create default administrator
            var defaultUser = new ApplicationUser
                {UserName = "administrator@localhost", Email = "administrator@localhost"};

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }
    }
}