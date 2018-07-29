using BookLibrary.Common;
using BookLibrary.Data;
using BookLibrary.Web.Models.BindingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Web.Controllers
{
    public class UsersController : Controller
    {
        private BookLibraryContext context;

        public UsersController(BookLibraryContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                this.ViewData["error"] = "Invalid data!";
                return this.View();
            }

            var user = this.context.Users
                .Where(x => x.UserName == model.UserName)
                .FirstOrDefault();

            if (user == null || user.PasswordHash != PasswordUtilities.GetPasswordHash(model.Password))
            {
                this.ViewData["error"] = "Incorrect username or password!";
                return this.View();
            }

            var session = this.HttpContext.Session;
            session.SetString("user", model.UserName);
            var userS = session.GetString("user");

            return this.Redirect("/");
        }

        public IActionResult Loguot()
        {
            return this.Redirect("/");
        }
    }
}
