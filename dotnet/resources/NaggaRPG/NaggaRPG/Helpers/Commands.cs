namespace NaggaRPG.Helpers
{
    public static class Commands
    {
        public const string Stats = "stats";
        public const string StatsAlias = "Stats,sts";

        public const string GetCoordonates = "getcoordonates";
        public const string GetCoordonatesAlias = "getcoords,GetCoordonates,GetCoords,mycoordonates,MyCoordonates,mycoords,MyCoords";

        #region Admin 1 commands

        public const string AdminChat = "a";
        public const string AdminChatAlias = "A";

        public const string GotoCoordonates = "gotocoordonates";
        public const string GotoCoordonatesAlias = "GotoCoordonates,gotocoords,GotoCoords,gotocoord,GotoCoord";

        public const string Goto = "goto";
        public const string GotoAlias = "Goto,gotoplayer,GotoPlayer";

        public const string SetTempSkin = "settempskin";
        public const string SetTempSkinAlias = "SetTempSkin,settemporaryskin,SetTemporarySkin";

        public const string SetHealth = "sethealth";
        public const string SetHealthAlias = "SetHealth,sethp,Sethp,SetHp";

        public const string SetArmor = "setarmor";
        public const string SetArmorAlias = "SetArmor";

        public const string Fly = "fly";
        public const string FlyAlias = "Fly,NoClip,noclip";

        public const string Freeze = "freeze";
        public const string FreezeAlias = "Freeze";

        public const string UnFreeze = "unfreeze";
        public const string UnFreezeAlias = "UnFreeze";

        public const string Mute = "mute";
        public const string MuteAlias = "Mute";

        public const string UnMute = "unmute";
        public const string UnMuteAlias = "UnMute";

        public const string Kick = "akick";
        public const string KickAlias = "AKick";

        #endregion Admin 1 commands

        #region Admin 2 commands

        public const string CreateVehicle = "createvehicle";
        public const string CreateVehicleAlias = "creatveh,CreateVehicle,CreateVeh";

        #endregion Admin 2 commands

        #region Admin 5 commands

        public const string MakeLeader = "makeleader";
        public const string MakeLeaderAlias = "setleader,MakeLeader,SetLeader";

        #endregion Admin 5 commands
    }
}