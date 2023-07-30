using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ByteBound.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ByteBound.Pages.Roles
{
    public class ManageModel : PageModel
    {
        private readonly ByteBound.Data.ByteBoundContext _context;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public ManageModel(ByteBound.Data.ByteBoundContext context,
        UserManager<Users> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public SelectList RolesSelectList;
        //contain a list of roles to populate select box
        public SelectList UsersSelectList;
        // contain a list of Users to populate select box
        public string selectedrolename { set; get; }
        public string selectedusername { set; get; }
        public string delrolename { set; get; }
        public string delusername { set; get; }
        public int usercountinrole { set; get; }
        public IList<ApplicationRole> Listroles { get; set; }
        public string ListUsersInRole(string rolename)
        {
            // Method - return a string showing a list of users based on the specified role as a parameter
            string strListUsersInRole = "";
            string roleid = _roleManager.Roles.SingleOrDefault(u => u.Name == rolename).Id;
            // Get the number of users for each specified role
            var count = _context.UserRoles.Where(u => u.RoleId == roleid).Count();
            usercountinrole = count;
            // Get a list of users for each specified role
            var listusers = _context.UserRoles.Where(u => u.RoleId == roleid);
            foreach (var oParam in listusers)
            { // loop through each object - get the username based on the userid and append to the returned string
                var userobj = _context.Users.SingleOrDefault(s => s.ID == oParam.UserId);
                strListUsersInRole += "[" + userobj.UserName + "] ";
            }
            return strListUsersInRole;
        }

        public async Task OnGetAsync()
        { //HTTPGet - when form is being loaded
          //get list of roles and users
            IQueryable<string> RoleQuery = from m in _roleManager.Roles orderby m.Name select m.Name;
            IQueryable<string> UsersQuery = from u in _context.Users orderby u.Username select u.Username;
            RolesSelectList = new SelectList(await RoleQuery.Distinct().ToListAsync());
            UsersSelectList = new SelectList(await UsersQuery.Distinct().ToListAsync());
            // Get all the roles
            var roles = from r in _roleManager.Roles
                        select r;
            Listroles = await roles.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(string selectedusername, string selectedrolename)
        {
            //When the Assign button is pressed
            if ((selectedusername == null) || (selectedrolename == null))
            {
                return RedirectToPage("Manage");
            }
            Users AppUser = _context.Users.SingleOrDefault(u => u.Username ==
            selectedusername);
            ApplicationRole AppRole = await _roleManager.FindByNameAsync(selectedrolename);
            IdentityResult roleResult = await _userManager.AddToRoleAsync(AppUser, AppRole.Name);
            if (roleResult.Succeeded)
            {
                TempData["message"] = "Role added to this user successfully";
                return RedirectToPage("Manage");
            }
            return RedirectToPage("Manage");
        }
        public async Task<IActionResult> OnPostDeleteUserRoleAsync(string delusername, string
        delrolename)
        {
            //When the Delete this user from Role button is pressed 
            if ((delusername == null) || (delrolename == null))
            {
                return RedirectToPage("Manage");
            }
            Users user = _context.Users.Where(u => u.Username == delusername).FirstOrDefault();
            if (await _userManager.IsInRoleAsync(user, delrolename))
            {
                await _userManager.RemoveFromRoleAsync(user, delrolename);
                TempData["message"] = "Role removed from this user successfully";
            }
            return RedirectToPage("Manage");
        }
    }
}