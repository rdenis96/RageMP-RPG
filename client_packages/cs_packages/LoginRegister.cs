using NaggaClientSide.Common;
using NaggaClientSide.Helpers;
using NaggaClientSide.Models;
using RAGE;

namespace NaggaClientSide
{
    public class LoginRegister
    {
        public async void OnPlayerConnected(params object[] args)
        {
            UserHelper.DisableUserControls(true);
            CommonHelper.ShowPage(true, ClientPages.LoginRegister);
            //Pages.MainPage.ExecuteJs($"showToastrMessage('{ClientPages.LoginRegister}','Contul a fost creat, te rugam sa te autentifici!',1)");
        }

        public async void SendLoginInformationToServer(params object[] args)
        {
            var loginModelJson = args[0] as string;
            Events.CallRemote("OnPlayerRegisterAttempt", loginModelJson);
        }

        public async void OnPlayerLoginResponse(params object[] args)
        {
            var playerInfo = args[0] as PlayerInfo;
            if (playerInfo != null)
            {
                Pages.MainPage.ExecuteJs($"showToastrMessage('{ClientPages.LoginRegister}', 'Autentificare reusita!', 0)");
                // mainPage.execute(`showToastrMessage('Autentificare reusita!', 0)`);
                UserHelper.DisableUserControls(false);
                CommonHelper.ShowPage(false);
                //RAGE.Game.Ui.SetNotificationMessage("Logare reusita", "Bine ai revenit, " + playerInfo.Username, "", "CHAR_SOCIAL_CLUB", icon = 0, flashing = false, textColor = -1, bgColor = -1, flashColor = [77, 77, 77, 200]);
            }
            else
            {
                // mainPage.execute(`showToastrMessage('Parola sau Username-ul sunt gresite!', 3)`);
                Pages.MainPage.ExecuteJs($"showToastrMessage('{ClientPages.LoginRegister}', 'Parola sau Username-ul sunt gresite!', 3)");
            }
        }

        public async void SendRegisterInformationToServer(params object[] args)
        {
            var registerModelJson = args[0] as string;
            Events.CallRemote("OnPlayerRegisterAttempt", registerModelJson);
        }

        public async void OnPlayerRegisterResponse(params object[] args)
        {
            var success = (args[0] as bool?).GetValueOrDefault();

            if (success)
            {
                Pages.MainPage.ExecuteJs($"showToastrMessage('{ClientPages.LoginRegister}','Contul a fost creat, te rugam sa te autentifici!', 1)");
                // mainPage.execute(`showToastrMessage('Contul a fost creat, te rugam sa te autentifici!', 1)`);
            }
            else
            {
                Pages.MainPage.ExecuteJs($"showToastrMessage('{ClientPages.LoginRegister}','Contul nu a putut fi creat, acesta exista sau a aparut o problema in timpul inregistrarii!', 3)");
                // mainPage.execute(`showToastrMessage('Contul nu a putut fi creat, acesta exista sau a aparut o problema in timpul inregistrarii!', 3)`);
            }
        }
    }
}