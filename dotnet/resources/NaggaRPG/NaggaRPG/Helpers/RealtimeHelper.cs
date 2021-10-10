using NaggaRPG.Models.Players;
using System.Collections.Generic;
using System.Timers;

namespace NaggaRPG.Helpers
{
    public class RealtimeHelper
    {
        public static Dictionary<long, Timer> PlayersPlayedTimeTimers { get; set; }

        static RealtimeHelper()
        {
        }

        public static void StartPlayedTimeCounting(PlayerInfo player)
        {
            Timer timer = new Timer();
            PlayersPlayedTimeTimers.Add(player.Id, timer);

            timer.Interval = 1000;
            timer.Elapsed += (object source, ElapsedEventArgs e) =>
            {
                player.TimePlayed += 1000;
            };
            timer.Start();
        }

        public static void StopPlayedTimeCounting(long playerInfoId)
        {
            bool canGetTimer = PlayersPlayedTimeTimers.TryGetValue(playerInfoId, out Timer timer);
            if (canGetTimer)
            {
                timer.Stop();
            }
        }
    }
}