using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
using SoftUni.WebServer.Mvc.Interfaces;

namespace CHUSHKA.App.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (this.User.IsAuthenticated)
            {
                var products = this.Context.Products
                    .Include(u => u.ProductType)
                    .ToList();

                var adminHello = this.User.IsInRole("Admin") ? "Enjoy your work today!" : "Feel free to view and order any of our products.";

                var result = new StringBuilder();
                result.Append($@"<main class=""mt-3 mb-5"">
                                    <div class=""container-fluid text-center"">
                                        <h2>Greetings, {this.User.Name}!</h2>
                                        <h4>{adminHello}</h4>
                                    </div>
                                    <hr class=""hr-2 bg-dark""/>
                                        <div class=""container-fluid product-holder"">
                                           <div class=""row d-flex justify-content-around"">");
                foreach (var product in products)
                {
                    result.AppendLine($@"<a href=""/products/details?id={product.Id}"" class=""col-md-2"">
                                            <div class=""product p-1 chushka-bg-color rounded-top rounded-bottom"">
                                                <h5 class=""text-center mt-3"">{product.Name}</h5>
                                                <hr class=""hr-1 bg-white""/>
                                                <p class=""text-white text-center"">
                                                    {product.Description}
                                                </p>
                                                <hr class=""hr-1 bg-white""/>
                                                <h6 class=""text-center text-white mb-3"">${product.Price}</h6>
                                            </div>
                                        </a>");
                }
                result.Append("</div>");

                result.Append("</div></main>");
                this.ViewData["result"] = result.ToString();

            }
            else
            {
                this.ViewData["result"] = @"<div class=""jumbotron mt-3 chushka-bg-color"">
                                                <h1>Welcome to Chushka Universal Web Shop</h1>
                                                <hr class=""bg-white"" />
                                                <h3><a class=""nav-link-dark"" href=""/users/login"">Login</a> if you have an account.</h3>
                                                <h3><a class=""nav-link-dark"" href=""/users/register"">Register</a> if you don't.</h3>
                                            </div>";
            }

            return this.View();
        }
    }
}
