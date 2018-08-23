namespace WCR.Services.Statistics.Interfaces
{
    using WCR.Common.Statistics.ViewModels;

    public interface IStatisticsService
    {
        UserStatViewModel GetUserStatistics(string userId);
    }
}
