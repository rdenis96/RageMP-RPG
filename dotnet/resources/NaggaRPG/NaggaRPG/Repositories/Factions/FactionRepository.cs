using Microsoft.EntityFrameworkCore;
using NaggaRPG.EntityContexts;
using NaggaRPG.Models.Factions;
using NaggaRPG.Repositories.Factions.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NaggaRPG.Repositories.Factions
{
    public class FactionRepository : BaseRepository<Faction>, IFactionRepository
    {
        public override async Task<IEnumerable<Faction>> GetAll()
        {
            using (var context = new MysqlContext())
            {
                var result = await context.Factions.ToListAsync();
                return result;
            }
        }

        public override async Task<Faction> GetById(int id)
        {
            using (var context = new MysqlContext())
            {
                var result = await context.Factions.FindAsync(id);
                return result;
            }
        }

        public override async Task<Faction> Create(Faction entity)
        {
            using (var context = new MysqlContext())
            {
                await context.Factions.AddAsync(entity);
                var savedChanges = await context.SaveChangesAsync() > 0;
                if (!savedChanges)
                {
                    throw new Exception($"Jucatorul nu a putut fi adaugat in factiunea {entity.FactionId.ToString()}");
                }
                return entity;
            }
        }
    }
}