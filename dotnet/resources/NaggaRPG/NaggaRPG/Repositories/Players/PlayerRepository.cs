using Microsoft.EntityFrameworkCore;
using NaggaRPG.EntityContexts;
using NaggaRPG.Models.Players;
using NaggaRPG.Repositories.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaggaRPG.Repositories.Players
{
    public class PlayerRepository : BaseRepository<PlayerInfo>, IPlayerRepository
    {
        public async Task<PlayerInfo> GetByAccountId(int id)
        {
            using (var context = new MysqlContext())
            {
                var result = await context.PlayersInfos.Where(x => x.AccountId == id).Include(x => x.Faction).FirstOrDefaultAsync();
                return result;
            }
        }

        public override async Task<PlayerInfo> Create(PlayerInfo entity)
        {
            using (var context = new MysqlContext())
            {
                await context.PlayersInfos.AddAsync(entity);
                var hasChanges = await context.SaveChangesAsync() > 0;
                if (!hasChanges)
                {
                    throw new Exception("Contul nu a putut fi creat.");
                }
                return entity;
            }
        }

        public override async Task<IEnumerable<PlayerInfo>> GetAll()
        {
            using (var context = new MysqlContext())
            {
                var result = await context.PlayersInfos.ToListAsync();
                return result;
            }
        }

        public override async Task<PlayerInfo> GetById(int id)
        {
            using (var context = new MysqlContext())
            {
                var result = await context.PlayersInfos.FindAsync(id);
                return result;
            }
        }
    }
}