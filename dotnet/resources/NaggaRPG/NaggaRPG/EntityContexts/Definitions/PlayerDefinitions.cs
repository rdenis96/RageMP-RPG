using Microsoft.EntityFrameworkCore;
using NaggaRPG.Models.Players;

namespace EntityContexts.Definitions
{
    internal static class PlayerDefinitions
    {
        public static void Set(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerInfo>().ToTable("PlayerInfos");

            modelBuilder.Entity<PlayerInfo>().HasKey(p => p.Id);
            modelBuilder.Entity<PlayerInfo>().Property(p => p.IsDeleted).IsRequired();
            modelBuilder.Entity<PlayerInfo>().Property(p => p.CreateDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<PlayerInfo>().Property(p => p.LastActiveDate).IsRequired().HasColumnType("datetime");

            modelBuilder.Entity<PlayerInfo>().Property(p => p.Level).IsRequired();
            modelBuilder.Entity<PlayerInfo>().Property(p => p.RespectPoints).IsRequired();
            //modelBuilder.Entity<PlayerInfo>().Property(p => p.SelectedSkin).IsRequired();
            //modelBuilder.Entity<PlayerInfo>().HasOne(p => p.Skin).WithMany().HasForeignKey(p => p.SkinId).IsRequired();
            modelBuilder.Entity<PlayerInfo>().Property(p => p.Health).IsRequired();
            modelBuilder.Entity<PlayerInfo>().Property(p => p.Armor).IsRequired();
            modelBuilder.Entity<PlayerInfo>().Property(p => p.PhoneNumber).IsRequired();
            modelBuilder.Entity<PlayerInfo>().Property(p => p.Money).IsRequired();
            modelBuilder.Entity<PlayerInfo>().Property(p => p.BankMoney).IsRequired();
            modelBuilder.Entity<PlayerInfo>().OwnsOne(p => p.Position,
               g =>
               {
                   g.Property(p => p.X).IsRequired();
                   g.Property(p => p.Y).IsRequired();
                   g.Property(p => p.Z).IsRequired();
               });
            modelBuilder.Entity<PlayerInfo>().OwnsOne(p => p.Rotation,
               g =>
               {
                   g.Property(p => p.X).IsRequired();
                   g.Property(p => p.Y).IsRequired();
                   g.Property(p => p.Z).IsRequired();
               });
            modelBuilder.Entity<PlayerInfo>().OwnsOne(p => p.IdCard,
               g =>
               {
                   g.Property(p => p.RealName).IsRequired();
                   g.Property(p => p.BirthDate).IsRequired();
                   g.Property(p => p.Sex).IsRequired();
               });
            modelBuilder.Entity<PlayerInfo>().OwnsOne(p => p.Admin,
               g =>
               {
                   g.Property(p => p.AdminLevel).IsRequired();
                   g.Ignore(p => p.AdminName);
               });
            modelBuilder.Entity<PlayerInfo>().OwnsOne(p => p.Mute,
                g =>
                {
                    g.Property(p => p.IsMuted).IsRequired();
                    g.Property(p => p.ExpirationTime).IsRequired().HasColumnType("datetime");
                    g.Property(p => p.Reason).IsRequired(false);
                });
            modelBuilder.Entity<PlayerInfo>().HasOne(p => p.Faction).WithMany().HasForeignKey(p => p.FactionInfoId).IsRequired();
            modelBuilder.Entity<PlayerInfo>().HasOne(p => p.Account).WithMany().HasForeignKey(p => p.AccountId).IsRequired();
            modelBuilder.Entity<PlayerInfo>().Property(p => p.Licenses).IsRequired();
            modelBuilder.Entity<PlayerInfo>().Property(p => p.TimePlayed).IsRequired();
        }
    }
}