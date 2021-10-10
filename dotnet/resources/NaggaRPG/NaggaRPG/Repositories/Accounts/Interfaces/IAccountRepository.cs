using NaggaRPG.Models.Accounts;
using System.Threading.Tasks;

namespace NaggaRPG.Repositories.Players.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetByUsername(string username);

        Task<Account> GetByUsernameAndPassword(string username, string password);
    }
}