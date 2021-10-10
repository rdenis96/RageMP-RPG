using RAGE;
using RAGE.Ui;

namespace NaggaClientSide.Common
{
    public static class Pages
    {
        public static HtmlWindow ChatPage { get; set; }
        public static HtmlWindow MainPage { get; set; }

        static Pages()
        {
            MainPage = new HtmlWindow("D:\\Games\\RAGEMP\\server-files\\client_packages\\NaggaServer\\Common\\main.html")
            {
                Active = false
            };

            Chat.Show(false);

            ChatPage = new HtmlWindow("D:\\Games\\RAGEMP\\server-files\\client_packages\\NaggaServer\\Global\\Chat\\index.html");
            ChatPage.MarkAsChat();
        }
    }
}