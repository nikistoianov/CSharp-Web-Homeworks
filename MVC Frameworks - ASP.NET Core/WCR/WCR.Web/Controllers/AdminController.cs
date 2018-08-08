using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WCR.Models;
using WCR.Data;
using WCR.Web.Models.ViewModels;

namespace WCR.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private const string MOD_ROLE = "Moderator";
        private readonly WCRDbContext db;
        private readonly UserManager<User> userManager;
        public AdminController(WCRDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult Users()
        {
            var model = new AdminUsersViewModel();
            var users = db.Users
                //.Select(UserListViewModel.FromUser)
                .ToList();
            foreach (var user in users)
            {
                var roles = userManager.GetRolesAsync(user);
                roles.Wait();
                
                var viewUser = UserListViewModel.FromUser(user);
                viewUser.Roles = roles.Result.ToArray();
                model.Users.Add(viewUser);
            }
            
            return View(model);
        }

        public IActionResult UserToModerator(string id, string returnUrl = "/")
        {
            var user = this.db.Users.Find(id);            

            var userRoles = userManager.GetRolesAsync(user);
            userRoles.Wait();

            if (!userRoles.Result.Contains(MOD_ROLE))
            {
                var newUserRole = userManager.AddToRoleAsync(user, MOD_ROLE);
                newUserRole.Wait();
            }

            return this.Redirect(returnUrl);
        }

        public IActionResult ModeratorToUser(string id, string returnUrl = "/")
        {
            var user = this.db.Users.Find(id);

            var userRoles = userManager.GetRolesAsync(user);
            userRoles.Wait();

            if (userRoles.Result.Contains(MOD_ROLE))
            {
                var newUserRole = userManager.RemoveFromRoleAsync(user, MOD_ROLE);
                newUserRole.Wait();
            }
            
            return this.Redirect(returnUrl);
        }
    }
}