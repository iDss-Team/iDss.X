using iDss.X.Models;
using Microsoft.AspNetCore.Identity;

namespace iDss.X.Data.Seed
{
    public static class IdentitySeeding
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string adminRole = "admin";
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            string adminUser = "idssxadmin";
            var user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = adminUser,
                    Email = "admin@ptncs.co.id",
                    branchid = 1,
                    grouptype = "admin",
                    passexpireddate = DateTime.Now.AddMonths(3),
                    passexpired = false,
                    loginattempt = 0,
                    securitycode = "ABC123"
                };
                var result = await userManager.CreateAsync(user, "idssxadmin");
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($"ERROR SEEDING: {error.Code} - {error.Description}");
                    }
                    return;
                }

                var addToRoleResult = await userManager.AddToRoleAsync(user, adminRole);
                if (!addToRoleResult.Succeeded)
                {
                    foreach (var error in addToRoleResult.Errors)
                    {
                        Console.WriteLine($"Error adding user to role: {error.Description}");
                    }
                }
            }
        }
    }
}
