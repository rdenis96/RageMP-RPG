using GTANetworkAPI;
using System;

namespace NaggaRPG.Helpers.Extensions
{
    public static class TryCatchExtension
    {
        public static void TryCatch(this Player player, Action func)
        {
            try
            {
                func();
            }
            catch (Exception ex)
            {
                player.TriggerEvent("OnErrorRaised", ex.Message);
            }
        }
    }
}