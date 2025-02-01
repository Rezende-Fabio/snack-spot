
using Microsoft.AspNetCore.Identity;

namespace snack_spot.Services;

public class SeedUsersRoleInitial : ISeedRoleInitial
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUsersRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void SeedRoles()
    {
        if (!_roleManager.RoleExistsAsync("Client").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Client";
            role.NormalizedName = "CLIENT";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }

        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
    }

    public void SeedUsers()
    {
        if (_userManager.FindByEmailAsync("admin@admin.com").Result == null)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = "admin";
            user.Email = "admin@admin.com";
            user.NormalizedUserName = "ADMIN";
            user.NormalizedEmail = "ADMIN@ADMIN.COM";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, "Admin123Qwe@").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}