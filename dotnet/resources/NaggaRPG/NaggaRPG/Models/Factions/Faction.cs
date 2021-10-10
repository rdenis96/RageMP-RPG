using NaggaRPG.Models.Common;
using NaggaRPG.Models.Factions.Enums;

namespace NaggaRPG.Models.Factions
{
    public class Faction : IChatBase, IDbEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public FactionId FactionId { get; set; }

        //public long SkinId { get; set; }
        public int Rank { get; set; }

        public int Warns { get; set; }
        public Mute Mute { get; set; }
    }
}