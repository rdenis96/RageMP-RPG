using GTANetworkAPI;
using NaggaRPG.Helpers;
using NaggaRPG.Helpers.Chat;
using NaggaRPG.Helpers.Extensions;
using NaggaRPG.Models.Players;
using NaggaRPG.Services.Players;
using System;
using System.Threading.Tasks;

namespace NaggaRPG.Scripts
{
    public class PlayerScript : Script
    {
        private readonly PlayerWorker _playerWorker;

        public PlayerScript()
        {
            _playerWorker = new PlayerWorker();
        }

        #region Commands

        [Command(Commands.GetCoordonates, Alias = Commands.GetCoordonatesAlias)]
        public Task GetCoordonates(Player player)
        {
            player.SendChatMessage($"Coordonates: X : {player.Position.X} | Y : {player.Position.Y} | Z : {player.Position.Z}");
            return Task.CompletedTask;
        }

        [Command(Commands.Stats, Alias = Commands.StatsAlias)]
        [RemoteEvent(Commands.Stats)]
        public Task Stats(Player player)
        {
            var playerInfo = player.GetPlayerInfo();
            if (playerInfo != null)
            {
                //var stats = PlayerStatisticsHelper.GetPlayerStatistics(player, playerInfo);

                //player.TriggerEvent(nameof(StatsCard.ShowStats), stats);
                //MOVE LOGIC TO CLIENT SIDE
            }
            else
            {
                player.SendChatMessage(ServerMessages.CommandError);
            }
            return Task.CompletedTask;
        }

        #endregion Commands

        #region ServerEvents

        [ServerEvent(Event.PlayerSpawn)]
        public Task OnPlayerSpawn(Player player)
        {
            return Task.CompletedTask;
        }

        [ServerEvent(Event.ChatMessage)]
        public async Task OnPlayerSendChatMessage(Player player, string message)
        {
            var playerInfo = player.GetPlayerInfo();
            if (playerInfo.Mute.IsMuted)
            {
                if (playerInfo.Mute.ExpirationTime > DateTime.UtcNow)
                {
                    player.SendChatMessage(PlayerMessages.Muted(playerInfo.Mute.Reason, playerInfo.Mute.ExpirationTime));
                }
                else
                {
                    playerInfo.Mute.IsMuted = false;
                    playerInfo.Mute.Reason = string.Empty;
                    await UpdatePlayerInfo(player, playerInfo);

                    await SendChatMessage(player, message);
                }
            }
            else
            {
                await SendChatMessage(player, message);
            }
        }

        #endregion ServerEvents

        #region PrivateMethods

        private async Task SetPlayerInfoOnSignIn(Player player, PlayerInfo dbPlayer)
        {
            dbPlayer.LastActiveDate = DateTime.UtcNow;

            RealtimeHelper.StartPlayedTimeCounting(dbPlayer);

            var positionToSpawn = new Vector3(dbPlayer.Position.X, dbPlayer.Position.Y, dbPlayer.Position.Z);
            NAPI.Player.SpawnPlayer(player, positionToSpawn);

            await UpdatePlayerInfo(player, dbPlayer);
        }

        private void SetPlayerInfoOnSpawn(Player player, PlayerInfo dbPlayer)
        {
            var isLogged = true; //TO BE MODIFIED
            if (isLogged)
            {
                player.Position = new Vector3(dbPlayer.Position.X, dbPlayer.Position.Y, dbPlayer.Position.Z);
                player.Rotation = new Vector3(dbPlayer.Rotation.X, dbPlayer.Rotation.Y, dbPlayer.Rotation.Z);

                NAPI.Entity.SetEntityTransparency(player, 255);
            }
        }

        private async Task SetPlayerInfoOnSignOut(Player player)
        {
            var playerInfo = player.GetPlayerInfo();
            RealtimeHelper.StopPlayedTimeCounting(playerInfo.Id);
            await _playerWorker.Update(playerInfo);
        }

        private Task SendChatMessage(Player player, string message)
        {
            var players = NAPI.Pools.GetAllPlayers();
            Parallel.ForEach(players, (clientPlayer) =>
            {
                clientPlayer.SendChatMessage(player.Name, message);
            });

            return Task.CompletedTask;
        }

        private async Task UpdatePlayerInfo(Player player, PlayerInfo playerInfo)
        {
            var updatedPlayer = await _playerWorker.Update(playerInfo);
            player.SetPlayerInfo(updatedPlayer);
        }

        #endregion PrivateMethods
    }
}