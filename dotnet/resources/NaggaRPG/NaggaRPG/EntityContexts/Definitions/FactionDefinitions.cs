using Microsoft.EntityFrameworkCore;
using NaggaRPG.Models.Factions;

namespace EntityContexts.Definitions
{
    internal static class FactionDefinitions
    {
        public static void Set(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faction>().ToTable("factions");

            modelBuilder.Entity<Faction>().HasKey(p => p.Id);
            modelBuilder.Entity<Faction>().Property(p => p.IsDeleted).IsRequired();
            modelBuilder.Entity<Faction>().Property(p => p.FactionId).IsRequired();
            modelBuilder.Entity<Faction>().Property(p => p.Rank).IsRequired();
            modelBuilder.Entity<Faction>().Property(p => p.Warns).IsRequired();
            modelBuilder.Entity<Faction>().OwnsOne(p => p.Mute,
                g =>
                {
                    g.Property(p => p.IsMuted).IsRequired();
                    g.Property(p => p.ExpirationTime).IsRequired().HasColumnType("datetime");
                    g.Property(p => p.Reason).IsRequired(false);
                });
        }
    }
}