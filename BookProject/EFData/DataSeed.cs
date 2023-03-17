using Domain;
using EFData.Exception;
using EFData.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace EFData
{
    public static class DataSeed
    {
        public static async Task SeedDataAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.Roles.AnyAsync())
            {
                foreach (var role in Enum.GetNames(typeof(Roles)))
                {
                    var resultCreateRole = await roleManager.CreateAsync(new IdentityRole() { Name = role });

                    if (!resultCreateRole.Succeeded)
                        throw new SeedDataException($"Don't append the {nameof(Roles)} as seed data");
                }
            }

            if (!await userManager.Users.AnyAsync())
            {
                var administrator = new AppUser() { Email = "admin@mail.ru", UserName = "Admin" };

                var resultCreateUser = await userManager.CreateAsync(administrator, "admin");

                if (!resultCreateUser.Succeeded)
                    throw new SeedDataException($"Don't append the {nameof(AppUser)} as seed data");

                var resultAddRole = await userManager.AddToRoleAsync(administrator, Roles.Administrator.ToString());

                if (!resultAddRole.Succeeded)
                    throw new SeedDataException($"Don't append the {nameof(Roles)} to {nameof(AppUser)}");
            }
        }
    }
}
