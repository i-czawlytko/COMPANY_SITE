using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CRM_ASP.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "admin";
        private const string adminPassword = "admin";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppIdentityDbContext>();
                context.Database.Migrate();
                UserManager<IdentityUser> userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                
                IdentityUser user = await userManager.FindByIdAsync(adminUser);
                if (user == null)
                {
                    user = new IdentityUser("admin");
                    await userManager.CreateAsync(user, adminPassword);
                }
            }
        }
    }
}
