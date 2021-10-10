using NaggaRPG.Helpers.Chat.Enums;
using NaggaRPG.Helpers.Common;
using System;

namespace NaggaRPG.Helpers.Chat
{
    public static class AdminMessages
    {
        public readonly static string CommandNotAuthorized;

        #region Commands on players

        public const string SetHealth = " i-a setat viata jucatorului ";

        public const string SetArmor = " i-a setat armura jucatorului ";

        public const string CreateVehicle = " a creat vehicul pentru jucatorul ";

        #endregion Commands on players

        public const string Freeze = " l-a blocat pe loc pe jucatorul ";
        public const string UnFreeze = " l-a deblocat de pe loc pe jucatorul ";

        public const string UnMute = " i-a scos mute-ul jucatorului ";

        public const string Goto = " s-a teleportat la jucatorul ";

        public const string Kick = " i-a dat kick jucatorului ";

        #region Commands on self

        public const string GoToCoordonates = " s-a teleportat la coordonatele ";

        #endregion Commands on self

        #region Commands error messages

        public const string NotFreezed = "Jucatorul nu este blocat!";

        #endregion Commands error messages

        static AdminMessages()
        {
            CommandNotAuthorized = $"{ChatColors.Red.GetDescription()}Nu esti autorizat sa accesezi aceasta comanda!";
        }

        public static string Mute(string adminName, string playerName, string reason, DateTime expirationTime)
        {
            return $@"{ChatColors.Orange.GetDescription()}Administratorul {adminName}
                                                {ChatColors.None.GetDescription()}i-a dat mute jucatorului
                                                {ChatColors.Orange.GetDescription()}{playerName}
                                                {ChatColors.None.GetDescription()}cu motivul
                                                {ChatColors.Orange.GetDescription()}{reason}
                                                {ChatColors.None.GetDescription()}pana la data de
                                                {ChatColors.Orange.GetDescription()} {expirationTime}!";
        }
    }
}