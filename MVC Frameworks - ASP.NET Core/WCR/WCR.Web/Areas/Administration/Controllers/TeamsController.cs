using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WCR.Services.Administration.Interfaces;

namespace WCR.Web.Areas.Administration.Controllers
{
    public class TeamsController : AdminController
    {
        private readonly IAdminService adminService;

        public TeamsController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        // GET: Teams
        public IActionResult Index()
        {
            var model = adminService.GetTeams();
            return View(model);
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
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

        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teams/Edit/5
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

        // GET: Teams/Delete/5
        public ActionResult Delete(int id, string returnUrl)
        {
            return View();
        }

        // POST: Teams/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, string returnUrl, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var result = await this.adminService.DeleteTeamAsync(id);
                if (result != null)
                {
                    this.ModelState.AddModelError(string.Empty, result);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return View(nameof(Index));
                //return RedirectToAction(nameof(Index));
                //return View();
            }
        }
    }
}