namespace WCR.Services.Competition
{
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
                    Score = x.FirstTeamGoals.ToString() + " : " + x.SecondTeamGoals ?? "no score" 
                })
                .ToArray();
            
            return matches;
        }
    }
}
