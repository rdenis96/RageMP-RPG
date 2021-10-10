using NaggaRPG.Models.Players.Enums;
using System;

namespace NaggaRPG.Models.Players
{
    public class IdentityCard
    {
        public string RealName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Sex { get; set; }
    }
}