namespace WCR.Services.Statistics
{
    using AutoMapper;
    using System.Linq;
    using WCR.Common.Statistics.ViewModels;
    using WCR.Data;
    using WCR.Services.Statistics.Interfaces;

    public class StatisticsService : BaseEFService, IStatisticsService
    {
        public StatisticsService(WCRDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        { }

        public UserStatViewModel GetUserStatistics(string userId)
        {
            var user = this.DbContext.Users
                .Where(x => x.Id == userId)
                .Select(x => new UserStatViewModel()
                {
                    ShortName = x.ShortName,
                    Email = x.Email,
                    BetsMatch = x.BetsForMatches.Count,
                    BetsTeam = x.BetsForPosition.Count
                })
                .SingleOrDefault();

            return user;
        }
    }
}
