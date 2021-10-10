using Microsoft.EntityFrameworkCore;
using NaggaRPG.EntityContexts;
using NaggaRPG.Models.Accounts;
using NaggaRPG.Repositories.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NaggaRPG.Repositories.Accounts
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public async Task<Account> GetByUsername(string username)
        {
            using (var context = new MysqlContext())
            {
                var result = await context.Accounts.FirstOrDefaultAsync(x => x.Username == username);
                return result;
            }
        }

        public async Task<Account> GetByUsernameAndPassword(string username, string password)
        {
            using (var context = new MysqlContext())
            {
                var result = await context.Accounts.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
                return result;
            }
        }

        public override async Task<Account> Create(Account entity)
        {
            using (var context = new MysqlContext())
            {
                await context.Accounts.AddAsync(entity);
                var hasChanges = await context.SaveChangesAsync() > 0;
                if (!hasChanges)
                {
                    throw new Exception("Contul nu a putut fi creat");
                }
                return entity;
            }
        }

        public override async Task<IEnumerable<Account>> GetAll()
        {
            using (var context = new MysqlContext())
            {
                var result = await context.Accounts.ToListAsync();
                return result;
            }
        }

        public override async Task<Account> GetById(int id)
        {
            using (var context = new MysqlContext())
            {
                var result = await context.Accounts.FindAsync(id);
                return result;
            }
        }
    }
}