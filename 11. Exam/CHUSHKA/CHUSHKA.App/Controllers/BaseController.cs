
namespace CHUSHKA.App.Controllers
{
    using System.Linq;
    using CHUSHKA.Data;
    using CHUSHKA.Models;
    using SoftUni.WebServer.Mvc.Interfaces;
    using SoftUni.WebServer.Mvc.Controllers;
    using Microsoft.EntityFrameworkCore;

    public class BaseController : Controller
    {
        protected BaseController()
        {
            this.Context = new ChushkaContext();
            this.ViewData.Data["error"] = string.Empty;
        }

        protected ChushkaContext Context { get; private set; }

        protected User DbUser { get; private set; }

        protected IActionResult RedirectToHome() => this.RedirectToAction("/home/index");

        public override void OnAuthentication()
        {
            var navbar = "";
            if (this.User.IsAuthenticated)
            {
                if (this.User.Roles.Contains("Admin"))
                {
                    navbar =
                        @"<div class=""collapse navbar-collapse d-flex justify-content-between"" id=""navbarNav"">
                            <ul class=""navbar-nav right-side"">
                                <li class=""nav-item"">
                                    <a class=""nav-link nav-link-white"" href=""/"">Home</a>
                                </li>
                                <li class=""nav-item"">
                                    <a class=""nav-link nav-link-white"" href=""/products/create"">Create Product</a>
                                </li>
                                <li class=""nav-item"">
                                    <a class=""nav-link nav-link-white"" href=""/orders/all"">All Orders</a>
                                </li>
                            </ul>
                            <ul class=""navbar-nav left-side"">
                                <li class=""nav-item"">
                                    <a class=""nav-link nav-link-white"" href=""/users/logout"">Logout</a>
                                </li>
                            </ul>
                        </div>";
                }
                else
                {
                    navbar =
                        @"<div class=""collapse navbar-collapse d-flex justify-content-between"" id=""navbarNav"">
                            <ul class=""navbar-nav right-side"">
                                <li class=""nav-item"">
                                    <a class=""nav-link nav-link-white"" href=""/"">Home</a>
                                </li>
                            </ul>
                            <ul class=""navbar-nav left-side"">
                                <li class=""nav-item"">
                                    <a class=""nav-link nav-link-white"" href=""/users/logout"">Logout</a>
                                </li>
                            </ul>
                        </div>";
                }
            }
            else
            {
                navbar = 
                @"<div class=""collapse navbar-collapse d-flex justify-content-between"" id=""navbarNav"">
                    <ul class=""navbar-nav"">
                        <li class=""nav-item"">
                            <a class=""nav-link nav-link-white"" href=""/"">Home</a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link nav-link-white"" href=""/users/login"">Login</a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link nav-link-white"" href=""/users/register"">Register</a>
                        </li>
                    </ul>
                </div>";
            }
            this.ViewData.Data["menu"] = navbar;

            if (this.User.IsAuthenticated)
            {
                this.DbUser = this.Context.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Username == this.User.Name);
            }

            base.OnAuthentication();
        }
    }
}
