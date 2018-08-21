using System.Threading.Tasks;
using WCR.Common.Competition.BindingModels;
using WCR.Models;

namespace WCR.Services.Competition.Interfaces
{
    public interface IBetService
    {
        BetMatchBindingModel PrepareBetMatch(int matchId);

        Task<string> AddBetMatchAsync(int matchId, string userId, int homeTeamGoals, int guestTeamGoals);

        BetMatchBindingModel GetBetMatch(int betId);

        Task<string> EditBetMatchAsync(int betId, int homeTeamGoals, int guestTeamGoals);

        BetMatch GetDbBetMatch(int id);
    }
}
