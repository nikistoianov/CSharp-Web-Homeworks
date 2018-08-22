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

        public IActionResult Groups()
        {
            var users = userManager.Users.ToList();
            var model = new GroupsViewModel()
            {
                //Users = this.mapper.Map<List<UserDetailsViewModel>>(users)
            };

            
            return View(model);
        }

        public IActionResult Rounds(int id)
        {
            var users = userManager.Users
                .OrderBy(x => x.ShortName)
                .ToList();

            var matches = roundService.GetMatches(id);
            var mappedUsers = this.mapper.Map<List<UserDetailsViewModel>>(users);
            var currentUserId = userManager.GetUserId(this.User);
            var isAdmin = this.User.IsInRole(Constants.ROLE_ADMIN);

            roundService.ArrangeScoreBets(matches, mappedUsers, currentUserId, isAdmin);

            var roundPoints = roundService.GetRoundResults(matches, users.Count);
            var bonusPoints = roundService.GetBonusResults(roundPoints);
            var totalPoints = roundService.GetTotalResults(roundPoints, bonusPoints);

            if (id > 1)
            {
                for (int i = 1; i < id; i++)
                {
                    var prevRoundPoints = roundService.GetRoundResults(i);
                    var prevBonusPoints = roundService.GetBonusResults(prevRoundPoints);
                    var prevTotalPoints = roundService.GetTotalResults(prevRoundPoints, prevBonusPoints);
                    totalPoints = roundService.JoinTotalResults(prevTotalPoints, totalPoints);
                }                
            }

            var model = new RoundViewModel()
            {
                Title = roundService.GetRoundTitle(id),
                Users = mappedUsers,
                Matches = matches,
                RoundPoints = roundPoints,
                BonusPoints = bonusPoints,
                TotalPoints = totalPoints
            };

            return View(model);
        }

    }
}