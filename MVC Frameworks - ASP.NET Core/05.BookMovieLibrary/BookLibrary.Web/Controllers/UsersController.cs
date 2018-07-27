using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Web.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Login()
        {
            return this.View();
        }
    }
}
