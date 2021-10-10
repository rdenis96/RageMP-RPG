using GTANetworkAPI;
using NaggaRPG.Models.Accounts;
using NaggaRPG.Models.Admins;
using NaggaRPG.Models.Common;
using NaggaRPG.Models.Factions;
using System;

namespace NaggaRPG.Models.Players
{
    public class PlayerInfo : IChatBase, IDbEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int Level { get; set; }
        public int RespectPoints { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastActiveDate { get; set; }

        //public SkinType SelectedSkin { get; set; }
        //public int SkinId { get; set; }
        //public Skin Skin { get; set; }
        public int Health { get; set; }

        public int Armor { get; set; }
        public int PhoneNumber { get; set; }
        public long Money { get; set; }
        public long BankMoney { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public IdentityCard IdCard { get; set; }
        public AdminInfo Admin { get; set; }
        public Mute Mute { get; set; }
        public Licenses Licenses { get; set; }
        public double TimePlayed { get; set; }

        public int FactionInfoId { get; set; }
        public Faction Faction { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}