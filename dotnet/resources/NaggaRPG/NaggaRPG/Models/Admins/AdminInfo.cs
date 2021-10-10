using NaggaRPG.Models.Admins.Enums;

namespace NaggaRPG.Models.Admins
{
    public class AdminInfo
    {
        public AdminLevels AdminLevel { get; set; }

        public string AdminName
        {
            get => nameof(AdminLevel);
        }

        public string ChatColor { get; set; }
    }
}