using EntityContexts.Definitions;
using Microsoft.EntityFrameworkCore;
using NaggaRPG.Helpers.Common;
using NaggaRPG.Models.Accounts;
using NaggaRPG.Models.Factions;
using NaggaRPG.Models.Players;

namespace NaggaRPG.EntityContexts
{
    public class MysqlContext : DbContext
    {
        public MysqlContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                var connectionString = ConnectionStrings.MysqlConnectionDatabase;
                var serverVersion = ServerVersion.AutoDetect(connectionString);

                optionsBuilder.UseMySql(connectionString, serverVersion);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<PlayerInfo> PlayersInfos { get; set; }

        //public DbSet<Skin> Skins { get; set; }
        public DbSet<Faction> Factions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AccountDefinitions.Set(modelBuilder);
            PlayerDefinitions.Set(modelBuilder);
            //SkinDefinitions.Set(modelBuilder);
            FactionDefinitions.Set(modelBuilder);
        }
    }
}