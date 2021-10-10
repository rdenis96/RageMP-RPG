using System.ComponentModel;

namespace NaggaRPG.Helpers.Chat.Enums
{
    public enum ChatColors
    {
        [Description("!{FFFFFF}")]
        None,

        [Description("!{FF0000}")]
        Red,

        [Description("!{#FFA500}")]
        Orange,

        [Description("!{#00FF00}")]
        Green,

        [Description("!{#009BFF}")]
        ChatAdmins
    }
}