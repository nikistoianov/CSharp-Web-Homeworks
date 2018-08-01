using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WCR.Web.Models;

namespace WCR.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly RoleManager<IdentityRole> roleManager;
        //public HomeController(RoleManager<IdentityRole> roleManager)
        //{
        //    this.roleManager = roleManager;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rules()
        {
            //Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Administrator");
            //hasAdminRole.Wait();

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
