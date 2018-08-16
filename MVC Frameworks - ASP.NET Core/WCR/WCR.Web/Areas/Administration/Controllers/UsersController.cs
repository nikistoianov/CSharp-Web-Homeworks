using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WCR.Models;
using WCR.Web.Areas.Administration.Models.ViewModels;

namespace WCR.Web.Areas.Administration.Controllers
{
    public class UsersController : AdminController
    {
        private const string MOD_ROLE = "Moderator";
        private readonly UserManager<User> userManager;

        public UsersController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        // GET: Users
        public ActionResult Index()
        {
            var model = new AdminUsersViewModel();
            var users = userManager.Users
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

        [HttpPost]
        public async Task<IActionResult> UserToModerator(string id, string returnUrl = "/")
        {
            var user = await this.userManager.FindByIdAsync(id);

            var userRoles = userManager.GetRolesAsync(user);
            userRoles.Wait();

            if (!userRoles.Result.Contains(MOD_ROLE))
            {
                var newUserRole = userManager.AddToRoleAsync(user, MOD_ROLE);
                newUserRole.Wait();
            }

            return this.Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> ModeratorToUser(string id, string returnUrl = "/")
        {
            var user = await this.userManager.FindByIdAsync(id);

            var userRoles = userManager.GetRolesAsync(user);
            userRoles.Wait();

            if (userRoles.Result.Contains(MOD_ROLE))
            {
                var newUserRole = userManager.RemoveFromRoleAsync(user, MOD_ROLE);
                newUserRole.Wait();
            }

            return this.Redirect(returnUrl);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}