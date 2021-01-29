using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.UI.IdentityInitializers
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new Role { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new Role { Name = "Member" });
            }


            var adminUser = await userManager.FindByNameAsync("Emre");
            if (adminUser == null)
            {
                User user = new User()
                {
                    Name = "Emre",
                    SurName = "Erdoğan",
                    UserName = "Emre",
                    Email = "Crazy60@gmail.com",

                };

                await userManager.CreateAsync(user, "123aabbCc.!");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

    }
}
