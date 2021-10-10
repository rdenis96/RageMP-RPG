using NaggaClientSide.Common;
using NaggaClientSide.Helpers;
using Newtonsoft.Json;
using RAGE;

namespace NaggaClientSide
{
    public class StatsCard
    {
        private bool _isStatsOpen = false;

        public StatsCard()
        {
            Input.Bind(0x71, false, () =>
            {
                Events.CallRemote("Stats");
            });
        }

        public async void ShowStats(params object[] args)
        {
            var stats = args[0];

            if (_isStatsOpen == false)
            {
                var statsJson = JsonConvert.SerializeObject(stats);
                CommonHelper.ShowPage(true, ClientPages.StatsCard);
                Pages.MainPage.ExecuteJs($"showStatsCard('{ClientPages.StatsCard}', '{statsJson}')");
                _isStatsOpen = true;
            }
            else
            {
                CommonHelper.ShowPage(false);
                _isStatsOpen = false;
            }
        }
    }
}