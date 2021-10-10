using RAGE;
using System;

namespace NaggaClientSide.Helpers
{
    public static class UserHelper
    {
        public static void DisableUserControls(bool shouldDisable)
        {
            try
            {
                if (shouldDisable)
                {
                    RAGE.Game.Ui.DisplayRadar(false);
                    RAGE.Elements.Player.LocalPlayer.Position = new Vector3(-427.65f, 1116.374f, 326.8f);
                    RAGE.Ui.Cursor.ShowCursor(true, true);
                    RAGE.Elements.Player.LocalPlayer.FreezePosition(true);
                    RAGE.Game.Player.SetPlayerInvincible(true);
                    ChatHelper.ActivateChat(false);
                }
                else
                {
                    RAGE.Game.Ui.DisplayRadar(true);
                    RAGE.Ui.Cursor.ShowCursor(false, false);
                    RAGE.Elements.Player.LocalPlayer.FreezePosition(false);
                    RAGE.Game.Player.SetPlayerInvincible(false);
                    ChatHelper.ActivateChat(true);
                }
            }
            catch (Exception ex)
            {
                //TO DO
                //LOG error
            }
        }
    }
}