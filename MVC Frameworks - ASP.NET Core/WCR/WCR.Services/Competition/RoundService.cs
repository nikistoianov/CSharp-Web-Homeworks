namespace WCR.Services.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using WCR.Common.Competition.ViewModels;
    using WCR.Data;
    using WCR.Services.Competition.Interfaces;

    public class RoundService : BaseEFService, IRoundService
    {
        public RoundService(WCRDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }

        public ICollection<MatchViewModel> GetMatches(int roundIndex, ICollection<UserDetailsViewModel> users)
        {
            var matches = this.DbContext.Matches
                .Where(x => x.RoundIndex == roundIndex)
                .Select(x => new MatchViewModel()
                {
                    Id = x.Id,
                    Date = x.Date,
                    FirstTeam = x.FirstTeam.Name,
                    SecondTeam = x.SecondTeam.Name,
                    Score = x.FirstTeamGoals.ToString() + " : " + x.SecondTeamGoals ?? "no score",
                    ScoreBets = x.Bets.Select(b => new ScoreBetViewModel()
                    {
                        Id = b.Id,
                        Score = b.FirstTeamGoals.ToString() + " : " + b.SecondTeamGoals.ToString(),
                        User = b.User.ShortName,
                        Hidden = x.Date < DateTime.Now,
                        Points = 11 // todo
                    }).ToArray()
                })
                .ToArray();

            ArrangeScoreBets(matches, users);
            
            return matches;
        }

        private void ArrangeScoreBets(MatchViewModel[] matches, ICollection<UserDetailsViewModel> users)
        {
            foreach (var match in matches)
            {
                var newScoreBets = new List<ScoreBetViewModel>();
                foreach (var user in users)
                {
                    var foundScoreBet = match.ScoreBets.FirstOrDefault(x => x.User == user.ShortName);
                    if (foundScoreBet == null)
                    {
                        newScoreBets.Add(new ScoreBetViewModel() { User = user.ShortName, Hidden = match.Date < DateTime.Now});
                    }
                    else
                    {
                        newScoreBets.Add(foundScoreBet);
                    }
                }
                match.ScoreBets = newScoreBets;
            }
        }
    }
}
