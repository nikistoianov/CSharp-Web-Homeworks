using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WCR.Data;
using WCR.Web.Models.ViewModels;

namespace WCR.Web.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly WCRDbContext db;
        private readonly IMapper mapper;

        public CompetitionController(WCRDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public ActionResult Groups()
        {
            var users = db.Users.ToList();
            var model = new GroupsViewModel()
            {
                Users = this.mapper.Map<List<UserDetailsViewModel>>(users)
            };


            return View(model);
        }

        public ActionResult Round(string id)
        {
            var users = db.Users.ToList();
            var model = new GroupsViewModel()
            {
                Users = this.mapper.Map<List<UserDetailsViewModel>>(users)
            };


            return View(model);
        }


        // GET: Rounds
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rounds/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rounds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rounds/Create
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

        // GET: Rounds/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rounds/Edit/5
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

        // GET: Rounds/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rounds/Delete/5
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