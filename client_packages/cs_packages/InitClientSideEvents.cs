using RAGE;

namespace NaggaClientSide
{
    public class InitClientSideEvents : Events.Script
    {
        private readonly LoginRegister _loginRegisterEvents;
        private readonly StatsCard _statsCardEvents;

        public InitClientSideEvents()
        {
            _loginRegisterEvents = new LoginRegister();
            _statsCardEvents = new StatsCard();

            Events.Add(nameof(LoginRegister.OnPlayerConnected), _loginRegisterEvents.OnPlayerConnected);
            Events.Add(nameof(LoginRegister.SendLoginInformationToServer), _loginRegisterEvents.SendLoginInformationToServer);
            Events.Add(nameof(LoginRegister.OnPlayerLoginResponse), _loginRegisterEvents.OnPlayerLoginResponse);
            Events.Add(nameof(LoginRegister.SendRegisterInformationToServer), _loginRegisterEvents.SendRegisterInformationToServer);
            Events.Add(nameof(LoginRegister.OnPlayerRegisterResponse), _loginRegisterEvents.OnPlayerRegisterResponse);

            Events.Add(nameof(StatsCard.ShowStats), _statsCardEvents.ShowStats);
        }
    }
}