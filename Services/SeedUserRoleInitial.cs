
using Microsoft.AspNetCore.Identity;

namespace snack_spot.Services;

public class SeedUsersRoleInitial : ISeedRoleInitial
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public SeedUsersRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
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
        string adminEmail = _configuration["AdminUser:Email"];
        string adminPassword = _configuration["AdminUser:Password"];

        if (_userManager.FindByEmailAsync(adminEmail).Result == null)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = "admin";
            user.Email = adminEmail;
            user.NormalizedUserName = "ADMIN";
            user.NormalizedEmail = adminEmail.ToUpper();
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, adminPassword).Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}