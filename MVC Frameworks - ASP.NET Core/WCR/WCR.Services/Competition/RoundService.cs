namespace WCR.Services.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using WCR.Common.Competition.ViewModels;
    using WCR.Common.Constants;
    using WCR.Data;
    using WCR.Models;
    using WCR.Services.Competition.Interfaces;

    public class RoundService : BaseEFService, IRoundService
    {
        public RoundService(WCRDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }

        public ICollection<MatchViewModel> GetMatches(int roundIndex)
        {
            var matches = this.DbContext.Matches
                .Where(x => x.RoundIndex == roundIndex)
                .Select(x => new MatchViewModel()
                {
                    Id = x.Id,
                    Date = x.Date,
                    FirstTeam = x.FirstTeam.Name,
                    SecondTeam = x.SecondTeam.Name,
                    Score = x.FirstTeamGoals.ToString() + " : " + x.SecondTeamGoals ?? Constants.NO_SCORE,
                    ScoreBets = x.Bets.Select(b => new ScoreBetViewModel()
                    {
                        Id = b.Id,
                        Score = b.FirstTeamGoals.ToString() + " : " + b.SecondTeamGoals.ToString(),
                        User = b.User.ShortName,
                        Points = CalculatePoints(b, b.Match) 
                    }).ToArray()
                })
                .OrderBy(x => x.Date)
                .ToArray();

            return matches;
        }

        // todo: CalculatePoints
        private int CalculatePoints(BetMatch bet, Match match)
        {
            return 1;
            throw new NotImplementedException();
        }

        public void ArrangeScoreBets(ICollection<MatchViewModel> matches, ICollection<UserDetailsViewModel> users, string currentUserId, bool isAdmin)
        {
            foreach (var match in matches)
            {
                var newScoreBets = new List<ScoreBetViewModel>();
                foreach (var user in users)
                {
                    var foundScoreBet = match.ScoreBets.FirstOrDefault(x => x.User == user.ShortName);
                    if (foundScoreBet == null)
                    {
                        foundScoreBet = new ScoreBetViewModel() { User = user.ShortName, Score = Constants.NO_SCORE};
                    }

                    foundScoreBet.Hidden = match.Date > DateTime.Now;
                    if ((currentUserId != null && currentUserId == user.Id) || isAdmin)
                    {
                        foundScoreBet.Current = true;
                        foundScoreBet.Hidden = false;
                    }
                    
                    foundScoreBet.MatchId = match.Id;
                    foundScoreBet.ClassName = GetScoreClass(foundScoreBet.Points);
                    if (foundScoreBet.Points > 0)
                    {
                        foundScoreBet.Score += $" ({foundScoreBet.Points})";
                    }

                    newScoreBets.Add(foundScoreBet);
                }
                match.ScoreBets = newScoreBets;
            }
        }

        private string GetScoreClass(int points)
        {
            switch (points)
            {
                case 0:
                    return Constants.CLASS_NO_SCORE;
                case Constants.POINTS_MATCH_SMALL_SCORE:
                    return Constants.CLASS_SMALL_SCORE;
                case Constants.POINTS_MATCH_BIG_SCORE:
                    return Constants.CLASS_BIG_SCORE;
                default:
                    return Constants.CLASS_NO_SCORE;
            }
        }
    }
}
