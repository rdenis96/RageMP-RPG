using NaggaRPG.Models.Players;
using System.Threading.Tasks;

namespace NaggaRPG.Repositories.Players.Interfaces
{
    public interface IPlayerRepository : IRepository<PlayerInfo>
    {
        Task<PlayerInfo> GetByAccountId(int id);
    }
}