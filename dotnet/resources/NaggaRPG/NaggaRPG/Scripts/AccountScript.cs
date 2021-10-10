using GTANetworkAPI;
using NaggaRPG.Dtos;
using NaggaRPG.Helpers;
using NaggaRPG.Helpers.Extensions;
using NaggaRPG.Models.Accounts;
using NaggaRPG.Services.Accounts;
using NaggaRPG.Services.Players;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NaggaRPG.Scripts
{
    public class AccountScript : Script
    {
        private readonly AccountWorker _accountWorker;
        private readonly PlayerWorker _playerWorker;

        public AccountScript()
        {
            _accountWorker = new AccountWorker();
            _playerWorker = new PlayerWorker();
        }

        #region ServerEvents

        [ServerEvent(Event.PlayerConnected)]
        public Task OnPlayerConnected(Player player)
        {
            NAPI.Entity.SetEntityTransparency(player, 0);
            player.Dimension = (uint)(player.Id + 1);

            var players = NAPI.Pools.GetAllPlayers().Where(x => x.Name == player.Name).ToList();
            if (players.Count > 1)
            {
                player.TriggerEvent("OnErrorRaised", "Un utilizator cu acelasi nume este deja conectat!");
            }
            else
            {
                player.TriggerEvent("OnPlayerConnected");
            }
            return Task.CompletedTask;
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public async Task OnPlayerDisconnected(Player player, DisconnectionType disconnectionType, string reason)
        {
            var account = await _accountWorker.GetByUsername(player.Name);
            if (account != null)
            {
                account.IsLogged = false;
            }

            var playerInfo = player.GetPlayerInfo();

            await _playerWorker.Update(playerInfo);
            await _accountWorker.Update(account);
        }

        #endregion ServerEvents

        #region RemoteEvent

        [RemoteEvent("OnPlayerLoginAttempt")]
        public Task OnPlayerLoginAttempt(Player player, string loginDto)
        {
            player.TryCatch(async () =>
            {
                LoginDto loginModel = JsonConvert.DeserializeObject<LoginDto>(loginDto);

                var encryptedPass = EncryptHelper.ComputeSha512Hash(loginModel.Password);

                var dbPlayer = await _accountWorker.GetByUsernameAndPassword(player.Name, encryptedPass);
                if (dbPlayer != null)
                {
                    dbPlayer.LastActiveDate = DateTime.UtcNow;
                    dbPlayer.IsLogged = true;

                    var playerCharacter = await _playerWorker.GetByAccountId(dbPlayer.Id);
                    if (playerCharacter != null)
                    {
                        player.SetPlayerInfo(playerCharacter);
                        player.TriggerEvent("OnPlayerLoginSuccess");
                    }
                    else
                    {
                        //Trigger the cinematic intro to create the character
                        //player.TriggerEvent("OnPlayerFirstLogin");
                    }
                }
                else
                {
                    player.TriggerEvent("LoginFailed");
                }
            });

            return Task.CompletedTask;
        }

        [RemoteEvent("OnPlayerRegisterAttempt")]
        public Task OnPlayerRegisterAttempt(Player player, string registerDto)
        {
            player.TryCatch(async () =>
            {
                RegisterDto registerModel = JsonConvert.DeserializeObject<RegisterDto>(registerDto);
                var account = await _accountWorker.GetByUsername(player.Name);
                if (account != null)
                {
                    player.TriggerEvent("OnErrorRaised", "Utilizatorul este deja inregistrat!");
                }
                else
                {
                    var encryptedPass = EncryptHelper.ComputeSha512Hash(registerModel.Password);
                    account = new Account
                    {
                        Username = player.Name,
                        Email = registerModel.Email,
                        Password = encryptedPass,
                        CreateDate = DateTime.UtcNow
                    };

                    _ = await _accountWorker.Create(account);
                    player.TriggerEvent("OnAccountRegisterSuccess");
                }
            });

            return Task.CompletedTask;
        }

        #endregion RemoteEvent
    }
}