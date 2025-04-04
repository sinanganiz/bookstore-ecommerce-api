using BookStore.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace BookStore.Data.Helper;

public class SeedData
{
    public static async void Initialize(IApplicationBuilder app)
    {
        var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

        string[] roles = new string[] { "Admin", "Customer" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new AppRole { Name = role });
            }
        }


        string adminEmail = "admin@admin.com";
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var adminUser = new AppUser
            {
                UserName = "admin",
                Email = adminEmail,
                Name = "Admin Name",
                Surname = "Admin Surname",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "admin123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }


        string customerEmail = "customer@customer.com";
        if (await userManager.FindByEmailAsync(customerEmail) == null)
        {
            var customerUser = new AppUser
            {
                UserName = "customer",
                Email = customerEmail,
                Name = "Customer Name",
                Surname = "Customer Surname",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(customerUser, "customer123");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(customerUser, "Customer");
            }
        }
    }
}
