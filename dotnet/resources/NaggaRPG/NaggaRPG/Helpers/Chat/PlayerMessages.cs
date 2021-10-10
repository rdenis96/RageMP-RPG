using NaggaRPG.Helpers.Chat.Enums;
using NaggaRPG.Helpers.Common;
using System;

namespace NaggaRPG.Helpers.Chat
{
    public static class PlayerMessages
    {
        #region Messages With Value

        public const string SetHealth = " ti-a setat viata ";

        public const string SetArmor = " ti-a setat armura ";

        public const string CreateVehicle = " ti-a creat vehiculul ";

        #endregion Messages With Value

        #region Messages Without Value

        public const string Freeze = " te-a blocat pe loc!";
        public const string UnFreeze = " te-a deblocat de pe loc!";

        public const string UnMute = " ti-a scos mute-ul!";

        public const string Goto = " s-a teleportat la tine!";

        public const string Kick = " ti-a dat kick!";

        #endregion Messages Without Value

        public static string Muted(string reason, DateTime expirationTime)
        {
            return $"Nu poti vorbi deoarece ai mute! Motiv: {reason} | Data de expirare: {expirationTime}";
        }

        public static string Mute(string adminName, string reason, DateTime expirationTime)
        {
            return $@"{ChatColors.Orange.GetDescription()}Administratorul {adminName}
                                                {ChatColors.None.GetDescription()}ti-a dat mute cu motivul:
                                                {ChatColors.Orange.GetDescription()}{reason}
                                                {ChatColors.None.GetDescription()}pana la data de
                                                {ChatColors.Orange.GetDescription()} {expirationTime}!";
        }
    }
}