using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WCR.Services.Administration.Interfaces;

namespace WCR.Web.Areas.Administration.Controllers
{
    public class MatchesController : AdminController
    {
        private readonly IAdminService adminService;

        public MatchesController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        // GET: Match
        public ActionResult Index()
        {
            var model = adminService.GetMatches();
            return View(model);
        }

        // GET: Match/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Match/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Match/Create
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

        // GET: Match/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Match/Edit/5
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

        // GET: Match/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Match/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var result = await this.adminService.DeleteMatchAsync(id);
                if (result != null)
                {
                    this.ModelState.AddModelError(string.Empty, result);
                    return View(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return View(nameof(Index));
            }
        }
    }
}