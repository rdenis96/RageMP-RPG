using Microsoft.EntityFrameworkCore;
using NaggaRPG.Models.Accounts;

namespace EntityContexts.Definitions
{
    internal static class AccountDefinitions
    {
        public static void Set(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("accounts");

            modelBuilder.Entity<Account>().HasKey(p => p.Id);
            modelBuilder.Entity<Account>().HasIndex(p => p.Username).IsUnique();
            modelBuilder.Entity<Account>().Property(p => p.IsDeleted).IsRequired();
            modelBuilder.Entity<Account>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<Account>().Property(p => p.Password).IsRequired();
            modelBuilder.Entity<Account>().Property(p => p.IsLogged).IsRequired();
            modelBuilder.Entity<Account>().Property(p => p.CreateDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Account>().Property(p => p.LastActiveDate).IsRequired().HasColumnType("datetime");
        }
    }
}