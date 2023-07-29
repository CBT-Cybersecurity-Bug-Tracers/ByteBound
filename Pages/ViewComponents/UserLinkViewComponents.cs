using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims; // Make sure to include this using statement
using System.Threading.Tasks;
using ByteBound.Models;

public class UserLinkViewComponent : ViewComponent
{
    private readonly UserManager<Users> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserLinkViewComponent(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        bool isAdmin = false;
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync((ClaimsPrincipal)User);
            if (user != null)
            {
                isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            }
        }

        return View(isAdmin);
    }
}
