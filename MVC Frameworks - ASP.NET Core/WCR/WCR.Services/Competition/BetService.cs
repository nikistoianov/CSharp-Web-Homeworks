using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WCR.Common.Competition.BindingModels;
using WCR.Data;
using WCR.Models;
using WCR.Services.Competition.Interfaces;

namespace WCR.Services.Competition
{
    public class BetService : BaseEFService, IBetService
    {
        public BetService(WCRDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }

        public BetMatchBindingModel PrepareBetMatch(int matchId)
        {
            var match = this.DbContext.Matches
                .Where(x => x.Id == matchId)
                .Select(x => new BetMatchBindingModel()
                {
                    HomeTeam = x.FirstTeam.Name,
                    GuestTeam = x.SecondTeam.Name
                })
                .SingleOrDefault();

            return match;
        }

        public async Task<string> AddBetMatchAsync(int matchId, string userId, int homeTeamGoals, int guestTeamGoals)
        {
            var bet = new BetMatch()
            {
                FirstTeamGoals = homeTeamGoals,
                SecondTeamGoals = guestTeamGoals,
                MatchId = matchId,
                UserId = userId
            };

            await this.DbContext.BetsForMatch.AddAsync(bet);
            await this.DbContext.SaveChangesAsync();

            return null;
        }

        public BetMatchBindingModel GetBetMatch(int betId)
        {
            var bet = this.DbContext.BetsForMatch
                .Where(x => x.Id == betId)
                .Select(x => new BetMatchBindingModel()
                {
                    HomeTeam = x.Match.FirstTeam.Name,
                    GuestTeam = x.Match.SecondTeam.Name,
                    HomeTeamGoals = x.FirstTeamGoals,
                    GuestTeamGoals = x.SecondTeamGoals
                })
                .SingleOrDefault();

            return bet;
        }

        public async Task<string> EditBetMatchAsync(int betId, int homeTeamGoals, int guestTeamGoals)
        {
            var bet = await this.DbContext.BetsForMatch.FindAsync(betId);
            if (bet == null)
            {
                return "Bet not found.";
            }

            bet.FirstTeamGoals = homeTeamGoals;
            bet.SecondTeamGoals = guestTeamGoals;

            await this.DbContext.SaveChangesAsync();
            return null;
        }

        public BetMatch GetDbBetMatch(int id)
        {
            var bet = this.DbContext.BetsForMatch.Find(id);
            return bet;
        }
    }
}
