using GTANetworkAPI;
using NaggaRPG.Models.Players;

namespace NaggaRPG.Helpers.Extensions
{
    public static class PlayerExtensions
    {
        public static PlayerInfo GetPlayerInfo(this Player player) => player.GetSharedData<PlayerInfo>(nameof(PlayerInfo));

        public static void SetPlayerInfo(this Player player, PlayerInfo updatedPlayerInfo)
        {
            player.SetSharedData(nameof(PlayerInfo), updatedPlayerInfo);
        }
    }
}