using NaggaClientSide.Common;

namespace NaggaClientSide.Helpers
{
    public static class ChatHelper
    {
        public static void ActivateChat(bool isActivated)
        {
            Pages.ChatPage.Active = isActivated;
            RAGE.Chat.Show(isActivated);
        }
    }
}