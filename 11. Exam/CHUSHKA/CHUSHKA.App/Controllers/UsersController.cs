using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CHUSHKA.App.Controllers
{
    using System.Linq;
    using CHUSHKA.App.Models.BindingModels;
    using CHUSHKA.Models;
    using SoftUni.WebServer.Common;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;

    public class UsersController : BaseController
    {
        [HttpGet]
        public IActionResult Register() => this.User.IsAuthenticated ? this.RedirectToHome() : this.View();


        [HttpPost]
        public IActionResult Register(UserRegisteringBindingModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            if (!this.IsValidModel(model))
            {
                this.ViewData.Data["error"] = "You have errors in your form.";
                return this.View();
            }

            string passwordHash = PasswordUtilities.GetPasswordHash(model.Password);

            var user = new User()
            {
                Username = model.Username,
                PasswordHash = passwordHash,
                FullName = model.FullName,
                Email = model.Email,
                RoleId = 1
            };

            using (this.Context)
            {
                this.Context.Users.Add(user);
                this.Context.SaveChanges();
            }

            this.SignIn(user.Username, user.Id, new List<string>(){"Admin"});
            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Login() => this.User.IsAuthenticated ? this.RedirectToHome() : this.View();

        [HttpPost]
        public IActionResult Login(UserLoggingInBindingModel model)
        {
            if (this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            if (!this.IsValidModel(model))
            {
                this.ViewData.Data["error"] = "You have errors in your form.";
                return this.View();
            }

            User user;
            using (this.Context)
            {
                user = this.Context.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Username == model.Username);
            }
            var passwordHash = PasswordUtilities.GetPasswordHash(model.Password);

            if (user == null || passwordHash != user.PasswordHash)
            {
                this.ViewData.Data["error"] = "Incorrect user or password.";
                return this.View();
            }

            this.SignIn(user.Username, user.Id, new List<string>() { user.Role.Name });
            return this.RedirectToHome();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (this.User.IsAuthenticated)
            {
                this.SignOut();
            }

            return this.RedirectToHome();
        }

    }
}
