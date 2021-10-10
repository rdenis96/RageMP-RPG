using System;

namespace NaggaRPG.Models.Common
{
    public class Mute
    {
        public bool IsMuted { get; set; }
        public DateTime ExpirationTime { get; set; }
        public string Reason { get; set; }
    }
}