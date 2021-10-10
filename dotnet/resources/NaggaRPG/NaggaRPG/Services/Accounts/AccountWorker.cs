using NaggaRPG.Models.Accounts;
using NaggaRPG.Repositories.Accounts;
using NaggaRPG.Repositories.Players;
using NaggaRPG.Repositories.Players.Interfaces;
using System.Threading.Tasks;

namespace NaggaRPG.Services.Accounts
{
    public class AccountWorker
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPlayerRepository _playerRepository;

        public AccountWorker()
        {
            _accountRepository = new AccountRepository();
            _playerRepository = new PlayerRepository();
        }

        public async Task<Account> GetByUsername(string username) => await _accountRepository.GetByUsername(username);

        public async Task<Account> GetByUsernameAndPassword(string username, string password) => await _accountRepository.GetByUsernameAndPassword(username, password);

        public async Task<Account> Create(Account entity) => await _accountRepository.Create(entity);

        public async Task<Account> Update(Account entity) => await _accountRepository.Update(entity);

        public async Task<Account> GetById(int id) => await _accountRepository.GetById(id);
    }
}