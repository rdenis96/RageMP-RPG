using GTANetworkAPI;

namespace NaggaRPG.Scripts
{
    public class ServerScript : Script
    {
        public ServerScript()
        {
        }

        #region ServerEvents

        [ServerEvent(Event.ResourceStart)]
        public void OnServerResourceStart()
        {
            NAPI.Server.SetAutoSpawnOnConnect(false);
            NAPI.Server.SetAutoRespawnAfterDeath(true);
            NAPI.Server.SetGlobalServerChat(false);
        }

        #endregion ServerEvents
    }
}