using System.Linq;
using System.Text;
using CHUSHKA.App.Models.BindingModels;
using CHUSHKA.Models;
using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
using SoftUni.WebServer.Mvc.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CHUSHKA.App.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            var productTypes = this.Context.ProductTypes
                .ToList();

            var types = new StringBuilder();
            foreach (ProductType productType in productTypes)
            {
                types.AppendLine($@"<label class=""radio-inline"" for=""{productType.Name}"">
                    <input type=""radio"" value=""{productType.Id}"" id=""{productType.Name}"" name=""ProductTypeId""> {productType.Name}
                    </label>");
            }

            this.ViewData.Data["types"] = types.ToString();

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(ProductBindingModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            if (!this.IsValidModel(model))
            {
                this.ViewData.Data["error"] = "You have errors in your form.";
                return this.View();
            }

            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ProductTypeId = model.ProductTypeId
            };

            using (this.Context)
            {
                this.Context.Products.Add(product);
                this.Context.SaveChanges();
            }

            return this.RedirectToAction($"/products/details?id={product.Id}");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            using (this.Context)
            {
                var product = this.Context.Products.Include(u => u.ProductType).FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return this.RedirectToHome();
                }

                if (this.User.IsInRole("Admin"))
                {
                    this.ViewData["adminButtons"] = $@"<a class=""btn chushka-bg-color"" href=""/products/edit?id={product.Id}"">Edit</a>
                        <a class=""btn chushka-bg-color"" href=""/products/delete?id={product.Id}"">Delete</a>";
                }
                else
                {
                    this.ViewData["adminButtons"] = string.Empty;
                }

                this.ViewData.Data["name"] = product.Name;
                this.ViewData.Data["price"] = product.Price.ToString();
                this.ViewData.Data["type"] = product.ProductType.Name;
                this.ViewData.Data["decription"] = product.Description;

                return this.View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!this.User.IsAuthenticated || !this.User.IsInRole("Admin"))
            {
                return this.RedirectToHome();
            }

            using (this.Context)
            {
                var product = this.Context.Products.Include(u => u.ProductType).FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return this.RedirectToHome();
                }

                var productTypes = this.Context.ProductTypes
                    .ToList();
                var types = new StringBuilder();
                foreach (ProductType productType in productTypes)
                {
                    types.AppendLine($@"<label class=""radio-inline"" for=""{productType.Name}"">
                    <input type=""radio"" value=""{productType.Id}"" id=""{productType.Name}"" name=""ProductTypeId""> {productType.Name}
                    </label>");
                }
                this.ViewData.Data["types"] = types.ToString();

                this.ViewData.Data["id"] = product.Id.ToString();
                this.ViewData.Data["name"] = product.Name;
                this.ViewData.Data["price"] = product.Price.ToString();
                //this.ViewData.Data["type"] = product.ProductType.Name;
                this.ViewData.Data["decription"] = product.Description;

                return this.View();
            }
        }
        
        [HttpPost]
        public IActionResult Edit(ProductBindingModel model)
        {
            var id = int.Parse(this.Request.QueryParameters.First().Value);
            if (!this.User.IsAuthenticated)
            {
                return this.RedirectToHome();
            }

            if (!this.IsValidModel(model))
            {
                this.ViewData.Data["error"] = "You have errors in your form.";
                return this.View();
            }

            using (this.Context)
            {
                var productDb = this.Context.Products.Include(u => u.ProductType).FirstOrDefault(p => p.Id == id);
                if (productDb == null)
                {
                    return this.RedirectToHome();
                }
                productDb.Name = model.Name;
                productDb.Price = model.Price;
                productDb.ProductTypeId = model.ProductTypeId;
                productDb.Description = model.Description;

                this.Context.SaveChanges();
            }
            
            return this.RedirectToAction($"/products/details?id={id}");
        }

    }
}
