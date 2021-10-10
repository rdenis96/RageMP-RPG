using NaggaClientSide.Common;

namespace NaggaClientSide.Helpers
{
    public static class CommonHelper
    {
        public static void ShowPage(bool canShow, string clientPage = ClientPages.None)
        {
            if (canShow)
            {
                Pages.MainPage.Active = canShow;
                Pages.MainPage.ExecuteJs($"showPage('{clientPage}')");
            }
            else
            {
                Pages.MainPage.ExecuteJs($"showPage('{ClientPages.None}')");
                Pages.MainPage.Active = canShow;
            }
        }
    }
}