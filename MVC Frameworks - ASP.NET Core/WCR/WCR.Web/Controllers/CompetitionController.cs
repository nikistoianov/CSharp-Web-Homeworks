using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WCR.Common.Competition.ViewModels;
using WCR.Common.Constants;
using WCR.Data;
using WCR.Models;
using WCR.Services.Competition.Interfaces;
using WCR.Web.Models.ViewModels;

namespace WCR.Web.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IRoundService roundService;

        public CompetitionController(UserManager<User> userManager, IMapper mapper, IRoundService roundService)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.roundService = roundService;
        }

        public ActionResult Groups()
        {
            var users = userManager.Users.ToList();
            var model = new GroupsViewModel()
            {
                //Users = this.mapper.Map<List<UserDetailsViewModel>>(users)
            };

            
            return View(model);
        }

        public ActionResult Rounds(int id)
        {
            var users = userManager.Users
                .OrderBy(x => x.ShortName)
                .ToList();

            var matches = roundService.GetMatches(id);
            var mappedUsers = this.mapper.Map<List<UserDetailsViewModel>>(users);
            var currentUserId = userManager.GetUserId(this.User);
            var isAdmin = this.User.IsInRole(Constants.ROLE_ADMIN);

            roundService.ArrangeScoreBets(matches, mappedUsers, currentUserId, isAdmin);

            var model = new RoundViewModel()
            {
                Users = mappedUsers,
                Matches = matches
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