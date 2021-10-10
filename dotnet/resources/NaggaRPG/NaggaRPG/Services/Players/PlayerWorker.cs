using NaggaRPG.Models.Players;
using NaggaRPG.Repositories.Players;
using NaggaRPG.Repositories.Players.Interfaces;
using System.Threading.Tasks;

namespace NaggaRPG.Services.Players
{
    public class PlayerWorker
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerWorker()
        {
            _playerRepository = new PlayerRepository();
        }

        public async Task<PlayerInfo> GetByAccountId(int id) => await _playerRepository.GetByAccountId(id);

        public async Task<PlayerInfo> Create(PlayerInfo entity) => await _playerRepository.Create(entity);

        public async Task<PlayerInfo> Update(PlayerInfo entity) => await _playerRepository.Update(entity);

        public async Task<PlayerInfo> GetById(int id) => await _playerRepository.GetById(id);
    }
}